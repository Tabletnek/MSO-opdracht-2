namespace MSO_Opdracht_3
{
    // The Repeat class implements the ITask interface and repeats a set of tasks a given number of times
    public class Repeat : IRepeat
    {
        public int Amount;  // Number of times to repeat the tasks
		public List<ITask> Tasks { get; private set; }  // List of tasks to repeat
		public int StepsDone { get; private set; }
		public int StepsLimit { get; private set; }


		// Constructor initializes the repeat task with a specified amount and tasks
		public Repeat(int amount, List<ITask> tasks)
        {
            this.Tasks = tasks;
            this.Amount = amount;
            this.StepsLimit = 1000000;
        }

        // Executes the tasks the specified number of times.
        void ITask.Execute(Player player, IGrid grid)
        {
	        //Stop at the stepsLimit, to handle infinite loops
			for (int i = 0; i < Amount; i++)
            {
	            foreach (ITask task in Tasks)
	            {
		            if (StepsDone >= StepsLimit)
		            {
			            throw new InvalidOperationException("Too many steps: the step limit has been reached.");
		            }

					task.Execute(player, grid);
		            StepsDone++;
				}

			}
		}

        // Returns a string representation of the repeated tasks.
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Amount; i++)
            {
                foreach (ITask task in Tasks)
                    result += task.ToString();
            }
            return result;
        }
	}
}
