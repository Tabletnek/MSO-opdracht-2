using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	public class Move : ITask
	{
		public int amount;
		public Move(int amount) 
		{
			this.amount = amount;
		}

		Player ITask.Execute(Player player)
		{
			switch (player.direction) 
			{
				case "North":
					player.position = new Point(player.position.X, player.position.Y + amount);
					return player;
				case "East":
					player.position = new Point(player.position.X + amount, player.position.Y);
					return player;
				case "South":
					player.position = new Point(player.position.X, player.position.Y - amount);
					return player;
				case "West":
					player.position = new Point(player.position.X - amount, player.position.Y);
					return player;
			}
			return player;
		}

		public override string ToString()
		{
			return $"Move {amount}, ";
		}
	}
}
