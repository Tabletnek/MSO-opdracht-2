﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_2
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			Program program= new Program();
			Translator translator = new Translator();
			Calculator calculator = new Calculator();

			Program basicProgram = new Program();
			basicProgram.AddTask(new Move(10));
			basicProgram.AddTask(new Turn("right"));

			Program advancedProgram = new Program();
			advancedProgram.AddTask(new Repeat(4, basicProgram.tasks));

			Program expertProgram = new Program();
			expertProgram.AddTask(new Repeat(3, advancedProgram.tasks));

            Console.WriteLine("Do you want to use one of the example programs or import one? Type 'Example' or 'Import'");
			string choice = Console.ReadLine();
			while (choice != null) 
			{
				if (choice == "Example")
				{
					Console.WriteLine("What example? Type 'Basic', 'Advanced', 'Expert'");
					string exampleType = Console.ReadLine();
					while (exampleType != null)
					{
						if (exampleType == "Basic")
						{
							program = basicProgram;
							break;
						}
						else if (exampleType == "Advanced")
						{
							program = advancedProgram;
							break;
						}
						else if (exampleType == "Expert")
						{
							program = expertProgram;
							break;
						}
						else
						{
							Console.WriteLine("Wrong answer. Type 'Basic', 'Advanced', 'Expert'");
							exampleType = Console.ReadLine();
						}
					}
					break;
				}
				else if (choice == "Import")
				{
					Console.WriteLine("Insert the text file into the same file as the cs files and type the filename here");
					string filename = Console.ReadLine();
					string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", filename);
					inputFilePath = Path.GetFullPath(inputFilePath);
					program = translator.TranslateFile(inputFilePath);
					break;
				}
				else
				{
					Console.WriteLine("Wrong answer. Type 'Example' or 'Import'");
					choice = Console.ReadLine();
				}
			}
			Console.WriteLine("Okay, now that we have selected a program, what do you want to do with it? Calculate or Run?");
			string choice2 = Console.ReadLine();
			while (choice2 != null)
			{
				if (choice2 == "Calculate")
				{
					Console.WriteLine($"The amount of commands of this program is: {calculator.numOfCommands(program)}");
					Console.WriteLine($"The amount of repeats of this program is: {calculator.numOfRepeats(program)}");
					Console.WriteLine($"The max level of nesting of this program is: {calculator.maxNestLvl(program)}");
					break;
				}
				else if (choice2 == "Run")
				{
					program.Run();
					break;

				}
				else
				{
					Console.WriteLine("Wrong answer. Type 'Calculate' or 'Run'");
					choice2 = Console.ReadLine();
				}
			}
		}
	}
}
