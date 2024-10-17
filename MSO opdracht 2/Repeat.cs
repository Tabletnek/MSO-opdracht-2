using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MSO_opdracht_2
{
	public class Repeat : ITask
	{
		public int amount;
		public List<ITask> tasks;
		public Repeat(int amount, List<ITask> tasks)
		{
			this.tasks = tasks;
			this.amount = amount;
		}
		Player ITask.Execute(Player player)
		{
			for (int i = 0; i < amount; i++)
			{
				foreach (ITask task in tasks)
					player = task.Execute(player);
			}
			return player;
		}

		public override string ToString()
		{
			string result = "";
			for (int i = 0; i < amount; i++)
			{
				foreach (ITask task in tasks)
					result += task.ToString();
			}
			return result;
		}
	}
}
