using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public class BoardDisplay : UserControl
	{
		private TaskProgram taskProgram;
		private int cellSize;
		private int cellAmount;

		public TaskProgram TaskProgram
		{
			get => taskProgram;
			set
			{
				taskProgram = value;
				UpdateCellAmount();
				cellSize = this.Width / cellAmount;
				Invalidate();
			}
		}

		public BoardDisplay()
		{
			this.DoubleBuffered = true;
			this.ResizeRedraw = true;
		}

		private void UpdateCellAmount()
		{
			if (taskProgram.grid.size == 0 && taskProgram.grid.visitedPoints.Count > 0)
			{
				int maxX = Math.Max(taskProgram.player.position.X, taskProgram.grid.visitedPoints.Max(p => p.X));
				int maxY = Math.Max(taskProgram.player.position.Y, taskProgram.grid.visitedPoints.Max(p => p.Y));
				int maxDimension = Math.Max(maxX, maxY) + 1; // Ensures zero index fits
				cellAmount = maxDimension;
			}
			else if (taskProgram.grid.size > 0)
			{
				cellAmount = taskProgram.grid.size;
			}
			else
			{
				cellAmount = 0; // Initial state: nothing to draw
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Only draw if there are points to show
			if (taskProgram == null || cellSize == 0) return;

			Graphics gr = e.Graphics;
			DrawGrid(gr);
			DrawVisitedPoints(gr);
			DrawPlayer(gr);
		}


		public void DrawPlayer(Graphics gr)
		{
			int x = taskProgram.player.position.X;
			int y = cellAmount - 1 - taskProgram.player.position.Y;
			{
				gr.FillRectangle(Brushes.Blue, x * cellSize, y * cellSize, cellSize, cellSize);
			}
		}

		public void DrawGrid(Graphics gr)
		{
			for (int y = 0; y < cellAmount; y++)
			{
				for (int x = 0; x < cellAmount; x++)
				{
					int flippedY = cellAmount - 1 - y;
					gr.DrawRectangle(Pens.Black, x * cellSize, flippedY * cellSize, cellSize, cellSize);
				}
			}

		}

		public void DrawVisitedPoints(Graphics gr)
		{
			foreach (Point point in taskProgram.grid.visitedPoints)
			{
				int x = point.X;
				int y = cellAmount - 1 - point.Y;
				{
					gr.FillRectangle(Brushes.Green, x * cellSize, y * cellSize, cellSize, cellSize);
				}
			}
		}

	}
}
