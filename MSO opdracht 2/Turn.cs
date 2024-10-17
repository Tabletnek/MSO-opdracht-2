using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	public class Turn : ITask
	{
		private string direction;
		public Turn(string direction)
		{
			this.direction = direction;
		}

		Player ITask.Execute(Player player)
		{
			switch (direction)
			{
				case "right":
					switch (player.direction)
					{
						case "North":
							player.direction = "East";
							return player;
						case "East":
							player.direction = "South";
							return player;
						case "South":
							player.direction = "West";
							return player;
						case "West":
							player.direction = "North";
							return player;
					}
					return player;
				case "left":
					switch (player.direction)
					{
						case "North":
							player.direction = "West";
							return player;
						case "East":
							player.direction = "North";
							return player;
						case "South":
							player.direction = "East";
							return player;
						case "West":
							player.direction = "South";
							return player;
					}
					return player;
			}
			return player;
		}

		public override string ToString()
		{
			return $"Turn {this.direction}, ";
		}
	}
}
