using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	public class Board
	{
		public int size;
		public List<Point> visitedPoints;
		public Board(int size)
		{
			this.size = size;
			this.visitedPoints = new List<Point>();
		}

		public void addVisitedPoint(Point point) 
		{
			if (this.visitedPoints.Contains(point)) return;
			else visitedPoints.Add(point);
		}

		public bool insideBoard(Point point)
		{
			int x = point.X; int y = point.Y;
			return x >= 0 && x <= size && y >= 0 && y <= size;
		}
	}
}
