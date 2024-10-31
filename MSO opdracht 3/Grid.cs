using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
	public class Grid : IGrid
	{
		public int Size { get; }
		public List<Point> VisitedPoints { get; set; }
		public Grid(int size)
		{
			this.Size = size;
			this.VisitedPoints = new List<Point>();
		}

		public void AddVisitedPoint(Point point)
		{
			if (this.VisitedPoints.Contains(point)) return;
			VisitedPoints.Add(point);
		}

		public bool InsideBoard(Point point)
		{
			int x = point.X; 
			int y = point.Y;
			if (this.Size == 0) return x >= 0 && y >= 0;
			return x >= 0 && x < Size && y >= 0 && y < Size;
		}

		public bool WallAhead(Player player)
		{
			return false;
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
	}
}
