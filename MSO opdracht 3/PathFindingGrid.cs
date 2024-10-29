using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public class PathFindingGrid : IGrid
	{
		public int size { get; }
		public List<Point> visitedPoints { get; set; }
		public List<Point> walls;
		public PathFindingGrid(int size)
		{
			this.size = size;
			this.visitedPoints = new List<Point>();
			this.walls = new List<Point>();
		}

		bool IGrid.InsideBoard(Point point)
		{
			return InsideBoard(point);
		}

		public void AddVisitedPoint(Point point)
		{
			if (this.visitedPoints.Contains(point)) return;
			visitedPoints.Add(point);
		}

		public void AddWall(Point point)
		{
			if (this.walls.Contains(point)) return;
			walls.Add(point);
		}

		public bool WallAhead(Player player)
		{
			string direction = player.direction;
			Point nextPosition = player.position;

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
			string direction = player.direction;
			Point nextPosition = player.position;

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
			return x >= 0 && x <= size && y >= 0 && y <= size;
		}

		private bool InsideWall(Point point)
		{
			return walls.Any(wall => wall == point);
		}
	}
}

