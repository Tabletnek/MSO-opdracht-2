using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public interface IGrid
	{
		public int size { get; }
		public List<Point> visitedPoints { get; set; }
		public bool InsideBoard(Point point);
		public void AddVisitedPoint(Point point);
		public bool WallAhead(Player player);
		public bool GridEdge(Player player);
	}
}
