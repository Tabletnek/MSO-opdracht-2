using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
	public class BoardDisplay : UserControl
	{
		private TaskProgram taskProgram;
		private float cellSize;
		private int cellAmount;

		public TaskProgram TaskProgram
		{
			get => taskProgram;
			set
			{
				taskProgram = value;
				UpdateCellAmount();
				if (cellAmount != 0)
				{
					cellSize = Math.Min((float)this.Width / cellAmount, (float)this.Height / cellAmount);
				}
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
			if (taskProgram == null) return;
			if (taskProgram.Grid.Size == 0 && taskProgram.Grid.VisitedPoints.Count > 0)
			{
				int maxX = Math.Max(taskProgram.Player.Position.X, taskProgram.Grid.VisitedPoints.Max(p => p.X));
				int maxY = Math.Max(taskProgram.Player.Position.Y, taskProgram.Grid.VisitedPoints.Max(p => p.Y));
				int maxDimension = Math.Max(maxX, maxY) + 1; // Ensures zero index fits
				cellAmount = maxDimension;
			}
			else if (taskProgram.Grid.Size > 0)
			{
				cellAmount = taskProgram.Grid.Size;
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
			DrawVisitedPoints(gr);
			if (taskProgram.Grid is PathFindingGrid)
			{
                DrawWalls(gr);
				DrawEndPoint(gr);
            }
			DrawPlayer(gr);
			DrawGrid(gr);
		}


		public void DrawPlayer(Graphics gr)
		{
			int x = taskProgram.Player.Position.X;
			int y = cellAmount - 1 - taskProgram.Player.Position.Y;
			{
				gr.FillRectangle(Brushes.Blue, x * cellSize, y * cellSize, cellSize, cellSize);
			}
		}

		public void DrawGrid(Graphics gr)
		{
			float gridSize = cellAmount * cellSize;

			// draw outer rectangle, this didnt show, because the last cells were just on the edge
			gr.DrawRectangle(Pens.Black, 0, 0, gridSize - 1, gridSize - 1);

			// Draw inner grid
			for (int y = 0; y < cellAmount; y++)
			{
				for (int x = 0; x < cellAmount; x++)
				{
					int flippedY = cellAmount - 1 - y;
					gr.DrawRectangle(Pens.Black, x * cellSize, flippedY * cellSize, cellSize , cellSize); // Adjust for inner rectangles if needed
				}
			}
		}

		public void DrawVisitedPoints(Graphics gr)
		{
			foreach (Point point in taskProgram.Grid.VisitedPoints)
			{
				int x = point.X;
				int y = cellAmount - 1 - point.Y;
				{
					gr.FillRectangle(Brushes.Green, x * cellSize, y * cellSize, cellSize, cellSize);
				}
			}
		}

        public void DrawWalls(Graphics gr)
        {
            PathFindingGrid pathGrid = (PathFindingGrid)taskProgram.Grid;
            foreach (Point point in pathGrid.Walls)
            {
                int x = point.X;
                int y = cellAmount - 1 - point.Y;
                {
                    gr.FillRectangle(Brushes.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }
        }

        public void DrawEndPoint(Graphics gr)
        {
	        PathFindingGrid pathGrid = (PathFindingGrid)taskProgram.Grid;
	        int x = pathGrid.EndPoint.X;
	        int y = cellAmount - 1 - pathGrid.EndPoint.Y;
	        gr.FillEllipse(Brushes.Gold, x * cellSize, y * cellSize, cellSize, cellSize);
        }

	}
}
