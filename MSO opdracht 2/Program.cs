using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_2
{
    // The Program class represents a program that consists of a player and a series of tasks
    public class Program
    {
        public Player player;
        public List<ITask> tasks;
        public Board board;

        // Initializes the player at (0, 0) facing East and creates an empty task list.
        public Program(int size)
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
        public void Run()
        {
            Player player = this.player;
            foreach (var task in tasks)
            {
                Console.Write(task.ToString());
                task.Execute(player, board);
            }
            Console.Write($"\nEnd state ({player.position.X}, {player.position.Y}), facing {player.direction}");
        }
    }
}
