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
		public Board board;

		public event Action<string> Output; // Declare an output event

		// Initializes the player at (0, 0) facing East and creates an empty task list.
		public TaskProgram(int size)
		{
			this.player = new Player(new Point(0, 0), "East");
			this.tasks = new List<ITask>();
			this.board = new Board(size);
		}

		// Adds a task to the task list
		public void AddTask(ITask task)
		{
			this.tasks.Add(task);
		}

		// Executes each task and prints the final state of the player
		public string Run()
		{
			string result = "";
			foreach (var task in tasks)
			{
				task.Execute(player, board);
				result += task.ToString();
			}
			result +=($"\r\nEnd state ({player.position.X}, {player.position.Y}), facing {player.direction}");
			return result;
		}
	}
}
