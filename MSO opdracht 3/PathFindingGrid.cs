namespace MSO_Opdracht_3
{
	public class PathFindingGrid : IGrid
	{
		public int Size { get; }
		public List<Point> VisitedPoints { get; set; }
		public List<Point> Walls;
		public Point EndPoint;
		public PathFindingGrid(int size)
		{
			this.Size = size;
			this.VisitedPoints = new List<Point>();
			this.Walls = new List<Point>();
		}

		public void ResetVisitedPoints()
		{
            this.VisitedPoints = new List<Point>();
        }

		bool IGrid.InsideBoard(Point point)
		{
			return InsideBoard(point);
		}

		public void AddVisitedPoint(Point point)
		{
			if (this.VisitedPoints.Contains(point)) return;
			VisitedPoints.Add(point);
		}

		public void AddWall(Point point)
		{
			if (this.Walls.Contains(point)) return;
			Walls.Add(point);
		}

		public bool WallAhead(Player player)
		{
			string direction = player.Direction;
			Point nextPosition = player.Position;

			switch (direction)
			{
				case "North":
					nextPosition.Y += 1;
					break;
				case "South":
					nextPosition.Y -= 1;
					break;
				case "West":
					nextPosition.X -= 1;
					break;
				case "East":
					nextPosition.X += 1;
					break;
			}
			return InsideWall(nextPosition);
		}

		public bool GridEdge(Player player)
		{
			string direction = player.Direction;
			Point nextPosition = player.Position;

			switch (direction)
			{
				case "North":
					nextPosition.Y += 1;
					break;
				case "South":
					nextPosition.Y -= 1;
					break;
				case "West":
					nextPosition.X -= 1;
					break;
				case "East":
					nextPosition.X += 1;
					break;
			}
			return !InsideBoard(nextPosition);
		}

		private bool InsideBoard(Point point)
		{
			int x = point.X;
			int y = point.Y;
			if (this.Size == 0) return x >= 0 && y >= 0;
			return x >= 0 && x < Size && y >= 0 && y < Size && !InsideWall(point);
		}

		public bool InsideWall(Point point)
		{
			return Walls.Any(wall => wall == point);
		}
	}
}

