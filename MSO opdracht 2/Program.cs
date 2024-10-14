using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	internal class Program
	{
		Player player;
		public List<ITask> tasks;
		public Program() 
		{
			this.player = new Player(new Point(0,0), "East");
			this.tasks = new List<ITask>();
		}

		public void AddTask(ITask task)
		{
			
			this.tasks.Add(task);
		}

		public void Run()
		{
			Player player = this.player;
			foreach (var task in tasks) 
			{
				Console.Write(task.ToString());
				player = task.Execute(player);
				//Console.WriteLine($"Current position: {player.position} facing {player.direction}");
			}
			Console.Write($"End state ({player.position.X}, {player.position.Y}), facing {player.direction}");
		}
	}
}
