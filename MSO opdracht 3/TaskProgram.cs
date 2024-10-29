using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_3
{
	// The Program class represents a program that consists of a player and a series of tasks
	public class TaskProgram
	{
		public Player player;
		public List<ITask> tasks;
		public IGrid grid;

		public event Action<string> Output; // Declare an output event

		// Initializes the player at (0, 0) facing East and creates an empty task list.
		public TaskProgram(int size)
		{
			this.player = new Player(new Point(0, 0), "East");
			this.tasks = new List<ITask>();
			this.grid = new Grid(size);
		}

		public TaskProgram(int size, IGrid grid)
		{
			this.player = new Player(new Point(0, 0), "East");
			this.tasks = new List<ITask>();
			this.grid = grid;
		}

		// Adds a task to the task list
		public void AddTask(ITask task)
		{
			this.tasks.Add(task);
		}

		// Executes each task and prints the final state of the player
		public string Run()
		{
			player.position = new Point(0, 0); player.direction = "East";
			grid.visitedPoints.Clear();
			//reset the player and board before running agai
			string result = "";
			foreach (var task in tasks)
			{
				task.Execute(player, grid);
				result += task.ToString();
			}
			result +=($"\r\nEnd state ({player.position.X}, {player.position.Y}), facing {player.direction}");
			return result;
		}
	}
}
