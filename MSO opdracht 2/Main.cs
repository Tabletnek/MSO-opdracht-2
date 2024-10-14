using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_2
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			Program program = new Program();
			Translator translator = new Translator();
			Calculator calculator = new Calculator();
			Move move = new Move(5);
			program.AddTask(new Move(5));
			program.AddTask(new Turn("right"));
			program.AddTask(new Move(3));

			List<ITask> repeatTasks = new List<ITask>()
			{
				new Turn("left"),   // Turn left (from South to East)
                new Move(2)         // Move 2 units East
            };
			program.AddTask(new Repeat(2, repeatTasks));  // Repeat those 2 tasks twice

			string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Input1.txt");
			inputFilePath = Path.GetFullPath(inputFilePath);  // Resolves the relative path to an absolute path

			Program program1 = translator.Translate(inputFilePath);
			program1.Run();
			Console.WriteLine();
			Console.WriteLine($"commands: {calculator.numOfCommands(program1)}, repeats: {calculator.numOfRepeat(program1)}");
		}
	}
}
