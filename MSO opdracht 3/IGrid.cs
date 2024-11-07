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
