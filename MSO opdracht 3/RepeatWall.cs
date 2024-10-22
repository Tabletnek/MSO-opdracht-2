using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public class RepeatWall : IRepeat
	{
		public List<ITask> tasks { get; private set; }  // List of tasks to repeat
		private List<string> executionLog; //Keeps track of all the tasks performed with this repeat.
		public RepeatWall(List<ITask> tasks)
		{
			this.tasks = tasks;
			this.executionLog = new List<string>();
		}

		void ITask.Execute(Player player, Board board)
		{
			executionLog.Clear(); //Empty the executionLog when running the repeat again. 

			while (!board.WallAhead(player)) //Keep executing tasks as long as the condition isn't met
			{
				foreach (ITask task in tasks)
				{
					task.Execute(player, board);
					executionLog.Add(task.ToString());


					if (board.WallAhead(player))
					{
						return; //If condition is true stop the loop
					}
				}
			}
		}
		public override string ToString()
		{
			string result = "";
			foreach (string task in executionLog)
			{
				result += task;
			}
			return result;
		}
	}
}
