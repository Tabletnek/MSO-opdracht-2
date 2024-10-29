using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public class Grid : IGrid
	{
		public int size { get; }
		public List<Point> visitedPoints { get; set; }
		public Grid(int size)
		{
			this.size = size;
			this.visitedPoints = new List<Point>();
		}

		public void AddVisitedPoint(Point point)
		{
			if (this.visitedPoints.Contains(point)) return;
			visitedPoints.Add(point);
		}

		public bool InsideBoard(Point point)
		{
			if (this.size == 0) return true;
			int x = point.X; 
			int y = point.Y;
			return x >= 0 && x < size && y >= 0 && y < size;
		}

		public bool WallAhead(Player player)
		{
			return false;
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
	}
}
