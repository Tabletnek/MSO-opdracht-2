namespace MSO_Opdracht_3
{
	public class RepeatEdge : IRepeat
	{
		public List<ITask> Tasks { get; private set; }  // List of tasks to repeat
		private List<string> _executionLog; //Keeps track of all the tasks performed with this repeat.
		public RepeatEdge(List<ITask> tasks) 
		{
			this.Tasks = tasks;
			this._executionLog = new List<string>();
		}

		void ITask.Execute(Player player, IGrid grid)
		{
			_executionLog.Clear(); //Empty the executionLog when running the repeat. 

			while (!grid.GridEdge(player)) //Keep executing tasks as long as the condition isn't met
			{
				foreach (ITask task in Tasks)
				{
					task.Execute(player, grid);
					_executionLog.Add(task.ToString());


					if (grid.GridEdge(player))
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
