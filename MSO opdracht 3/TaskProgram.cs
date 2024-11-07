namespace MSO_Opdracht_3
{
	// The Program class represents a program that consists of a player and a series of tasks
	public class TaskProgram
	{
		public Player Player;
		public List<ITask> Tasks;
		public IGrid Grid;

		// Initializes the player at (0, 0) facing East and creates an empty task list.
		public TaskProgram(int size)
		{
			this.Player = new Player(new Point(0, 0), "East");
			this.Tasks = new List<ITask>();
			this.Grid = new Grid(size);
		}

		public TaskProgram(int size, IGrid grid)
		{
			this.Player = new Player(new Point(0, 0), "East");
			this.Tasks = new List<ITask>();
			this.Grid = grid;
		}

		// Adds a task to the task list
		public void AddTask(ITask task)
		{
			this.Tasks.Add(task);
		}

		// Executes each task and prints the final state of the player
		public string Run()
		{
			ResetPlayer();
			Grid.VisitedPoints.Clear();
			//reset the player and board before running again
			string result = "";
			foreach (var task in Tasks)
			{
				task.Execute(Player, Grid);
				result += task.ToString();
			}
			result +=($"\r\nEnd state ({Player.Position.X}, {Player.Position.Y}), facing {Player.Direction}");
			return result;
		}
		public void ResetPlayer()
		{
			if (Grid is PathFindingGrid)
			{
                Player.Position = new Point(0, Grid.Size - 1); Player.Direction = "East";
            }  
			else
			{
                Player.Position = new Point(0, 0); Player.Direction = "East";
            }
        }
	}
}
