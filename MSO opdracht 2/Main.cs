using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_2
{
	public class MainClass
	{
		// Where the application starts
		public static void Main(string[] args)
		{
			// Create instances of classes we use
			Program program = new Program(5); // Replaced later with the program we want to use
			Translator translator = new Translator();
			Calculator calculator = new Calculator();

			// Create the Example Programs
			Program basicProgram = new Program(10);
			basicProgram.AddTask(new Move(10));
			basicProgram.AddTask(new Turn("left"));

			Program advancedProgram = new Program(10);
			advancedProgram.AddTask(new Repeat(4, basicProgram.tasks));

			Program expertProgram = new Program(10);
			expertProgram.AddTask(new Repeat(3, advancedProgram.tasks));

			// Start the conversation with the user
            Console.WriteLine("Do you want to use one of the example programs or import one? Type 'Example' or 'Import'");
			string choice = Console.ReadLine();
			while (choice != null) 
			{
				if (choice == "Example")
				{
					Console.WriteLine("What example? Type 'Basic', 'Advanced', 'Expert'");
					string exampleType = Console.ReadLine();

					// Replace our current empty program with the chosen program
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
                            // In case the wrong input is given, restart the loop
                            Console.WriteLine("Wrong answer. Type 'Basic', 'Advanced', 'Expert'"); 
							exampleType = Console.ReadLine();
						}
					}
					break;
				}
				else if (choice == "Import")
				{
					Console.WriteLine("Insert the text file into the same folder as the cs files and type the filename here. e.g. Input1");
					string filename = Console.ReadLine();
					while (filename != null)
					{
						//For the path finding we used https://stackoverflow.com/questions/15653921/get-current-folder-path
						string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", filename + ".txt");
						inputFilePath = Path.GetFullPath(inputFilePath);
						//To check if a file exists we used https://www.geeksforgeeks.org/file-exists-method-in-c-sharp-with-examples/
						if (File.Exists(inputFilePath))
						{
							program = translator.TranslateFile(inputFilePath); // Use the translator to translate the file
							choice = null;
							break;
						}
						else
						{
                            // In case the wrong input is given, restart the loop
                            Console.WriteLine("This file doesn't exist. Make sure to enter an existing file name, without .txt)");
							filename = Console.ReadLine();
						}
					}
				}
				else
				{
                    // In case the wrong input is given, restart the loop
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
					// Use the calculator to calculate aspects of the program
					Console.WriteLine($"The amount of commands of this program is: {calculator.numOfCommands(program)}");
					Console.WriteLine($"The amount of repeats of this program is: {calculator.numOfRepeats(program)}");
					Console.WriteLine($"The max level of nesting of this program is: {calculator.maxNestLvl(program)}");
					break;
				}
				else if (choice2 == "Run")
				{
					// Run the program
					program.Run();
					break;
				}
				else
				{
                    // In case the wrong input is given, restart the loop
                    Console.WriteLine("Wrong answer. Type 'Calculate' or 'Run'");
					choice2 = Console.ReadLine();
				}
			}
			// Exit the application
			Console.WriteLine("\nPress any key to exit...");
			Console.ReadKey();
		}
	}
}
