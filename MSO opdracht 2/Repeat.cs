using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MSO_opdracht_2
{
    // The Repeat class implements the ITask interface and repeats a set of tasks a given number of times
    public class Repeat : ITask
    {
        public int amount;  // Number of times to repeat the tasks
        public List<ITask> tasks;  // List of tasks to repeat

        // Constructor initializes the repeat task with a specified amount and tasks
        public Repeat(int amount, List<ITask> tasks)
        {
            this.tasks = tasks;
            this.amount = amount;
        }

        // Executes the tasks the specified number of times.
        Player ITask.Execute(Player player)
        {
            for (int i = 0; i < amount; i++)
            {
                foreach (ITask task in tasks)
                    player = task.Execute(player);
            }
            return player; // Return the updated player after executing the tasks in the loop
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
    }
}
