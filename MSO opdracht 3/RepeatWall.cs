﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
	public class RepeatWall : IRepeat
	{
		public List<ITask> Tasks { get; private set; }  // List of tasks to repeat
		public int StepsDone { get; private set; }
		public int StepsLimit { get; private set; }

		private List<string> _executionLog; //Keeps track of all the tasks performed with this repeat.
		public RepeatWall(List<ITask> tasks)
		{
			this.Tasks = tasks;
			this._executionLog = new List<string>();
			this.StepsLimit = 10000;
		}

		void ITask.Execute(Player player, IGrid grid)
		{
			_executionLog.Clear(); //Empty the executionLog when running the repeat. 

			while (!grid.WallAhead(player)) //Keep executing tasks as long as the condition isn't met
			{
				foreach (ITask task in Tasks)
				{
					//Stop at the stepsLimit, to handle infinite loops
					if (StepsDone >= StepsLimit)
					{
						throw new InvalidOperationException("Too many steps: the step limit has been reached.");
					}

					task.Execute(player, grid);
					_executionLog.Add(task.ToString());
					StepsDone++;

					if (grid.WallAhead(player))
					{
						return; //If condition is true stop the loop
					}
				}
			}
		}
		public override string ToString()
		{
			string result = "";
			foreach (string task in _executionLog)
			{
				result += task;
			}
			return result;
		}
	}
}
