using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	public class Player
	{
		public Point position {  get; set; }
		public string direction { get; set; }
		public Player(Point pos, string dir)
		{
			this.position = pos;
			this.direction = dir;
		}
	}
}
