using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
    // The Translator class translates a text file to a program
    public class Translator
    {
        string line; // A line from the text file
        int size;

        // This method starts the StreamReader and initializes the translation process
        public Program TranslateFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
			line = sr.ReadLine();
			var splitFirstLine = line.Split(" ");
			size = int.Parse(splitFirstLine[1]);
            line = sr.ReadLine();
			return TranslateProgram(sr, 0);
        }

        // Creates a new program, which is used when initially translating a file and for using Repeat
        public Program TranslateProgram(StreamReader sr, int nestedLoops)
        {

            Program program = new Program(size);
            while (line != null)
            {
                if (nestedLoops > 0) // If we're in a Repeat loop, the amount of nestedLoops is larger than 0
                {
                    char indent = line[nestedLoops - 1]; // This checks if the level of indentation matches how nested the loop is
                    if (indent != '\t')                  // If it isn't, we exit the current loop
                    {                                    
                        return program;                  // We don't move on to the next line when we exit the loop.                                
                    }                                    // That's because we haven't added the task of our current line yet 
                }
                string trimmedLine = line.Trim(); // Read the line without any indentation
                var split = trimmedLine.Split(" ");
                string task = split[0];  // Reads the task
                line = sr.ReadLine();    // Readys the next line before adding the current task. If we don't, the method will use the old line when adding a new Repeat loop
                switch (task)
                {
                    case "Move":
                        program.AddTask(new Move(int.Parse(split[1]))); break;
                    case "Turn":
                        program.AddTask(new Turn(split[1])); break;
                    case "Repeat":
                        program.AddTask(new Repeat(int.Parse(split[1]), TranslateProgram(sr, nestedLoops + 1).tasks)); break; // Creates a new program to use for our loop
                }
            }
            return program;  // If we reached the end of the text file, we return the program
        }
    }
}
