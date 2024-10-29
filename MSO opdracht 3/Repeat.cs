using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MSO_opdracht_3
{
    // The Repeat class implements the ITask interface and repeats a set of tasks a given number of times
    public class Repeat : IRepeat
    {
        public int amount;  // Number of times to repeat the tasks
		public List<ITask> tasks { get; private set; }  // List of tasks to repeat


		// Constructor initializes the repeat task with a specified amount and tasks
		public Repeat(int amount, List<ITask> tasks)
        {
            this.tasks = tasks;
            this.amount = amount;
        }

        // Executes the tasks the specified number of times.
        void ITask.Execute(Player player, IGrid grid)
        {
            for (int i = 0; i < amount; i++)
            {
                foreach (ITask task in tasks)
                    task.Execute(player, grid);
            }
        }

        // Returns a string representation of the repeated tasks.
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

		public void Execute(Player player, Grid board)
		{
			throw new NotImplementedException();
		}
	}
}
