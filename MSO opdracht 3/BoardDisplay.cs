namespace MSO_Opdracht_3
{
	public class BoardDisplay : UserControl
	{
		private TaskProgram _taskProgram;
		private float _cellSize;
		private int _cellAmount;

		public TaskProgram TaskProgram
		{
			get => _taskProgram;
			set
			{
				_taskProgram = value;
				UpdateCellAmount();
				if (_cellAmount != 0)
				{
					_cellSize = Math.Min((float)this.Width / _cellAmount, (float)this.Height / _cellAmount);
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
			if (_taskProgram == null) return;
			if (_taskProgram.Grid.Size == 0 && _taskProgram.Grid.VisitedPoints.Count > 0)
			{
				int maxX = Math.Max(_taskProgram.Player.Position.X, _taskProgram.Grid.VisitedPoints.Max(p => p.X));
				int maxY = Math.Max(_taskProgram.Player.Position.Y, _taskProgram.Grid.VisitedPoints.Max(p => p.Y));
				int maxDimension = Math.Max(maxX, maxY) + 1; // Ensures zero index fits
				_cellAmount = maxDimension;
			}
			else if (_taskProgram.Grid.Size > 0)
			{
				_cellAmount = _taskProgram.Grid.Size;
			}
			else
			{
				_cellAmount = 0; // Initial state: nothing to draw
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Only draw if there are points to show
			if (_taskProgram == null || _cellSize == 0) return;

			Graphics gr = e.Graphics;
			DrawVisitedPoints(gr);
			if (_taskProgram.Grid is PathFindingGrid)
			{
                DrawWalls(gr);
				DrawEndPoint(gr);
            }
			DrawPlayer(gr);
			DrawGrid(gr);
		}


		public void DrawPlayer(Graphics gr)
		{
			int x = _taskProgram.Player.Position.X;
			int y = _cellAmount - 1 - _taskProgram.Player.Position.Y;
			{
				gr.FillRectangle(Brushes.Blue, x * _cellSize, y * _cellSize, _cellSize, _cellSize);
			}
		}

		public void DrawGrid(Graphics gr)
		{
			float gridSize = _cellAmount * _cellSize;

			// draw outer rectangle, this didnt show, because the last cells were just on the edge
			gr.DrawRectangle(Pens.Black, 0, 0, gridSize - 1, gridSize - 1);

			// Draw inner grid
			for (int y = 0; y < _cellAmount; y++)
			{
				for (int x = 0; x < _cellAmount; x++)
				{
					int flippedY = _cellAmount - 1 - y;
					gr.DrawRectangle(Pens.Black, x * _cellSize, flippedY * _cellSize, _cellSize, _cellSize); // Adjust for inner rectangles if needed
				}
			}
		}

		public void DrawVisitedPoints(Graphics gr)
		{
			foreach (Point point in _taskProgram.Grid.VisitedPoints)
			{
				int x = point.X;
				int y = _cellAmount - 1 - point.Y;
				{
					gr.FillRectangle(Brushes.Green, x * _cellSize, y * _cellSize, _cellSize, _cellSize);
				}
			}
		}

        public void DrawWalls(Graphics gr)
        {
            PathFindingGrid pathGrid = (PathFindingGrid)_taskProgram.Grid;
            foreach (Point point in pathGrid.Walls)
            {
                int x = point.X;
                int y = _cellAmount - 1 - point.Y;
                {
                    gr.FillRectangle(Brushes.Black, x * _cellSize, y * _cellSize, _cellSize, _cellSize);
                }
            }
        }

        public void DrawEndPoint(Graphics gr)
        {
	        PathFindingGrid pathGrid = (PathFindingGrid)_taskProgram.Grid;
	        int x = pathGrid.EndPoint.X;
	        int y = _cellAmount - 1 - pathGrid.EndPoint.Y;
	        gr.FillEllipse(Brushes.Gold, x * _cellSize, y * _cellSize, _cellSize, _cellSize);
        }

	}
}
