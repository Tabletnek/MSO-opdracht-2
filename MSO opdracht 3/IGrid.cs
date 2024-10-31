using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
	public interface IGrid
	{
		public int Size { get; }
		public List<Point> VisitedPoints { get; set; }
		public bool InsideBoard(Point point);
		public void AddVisitedPoint(Point point);
		public bool WallAhead(Player player);
		public bool GridEdge(Player player);
	}
}
