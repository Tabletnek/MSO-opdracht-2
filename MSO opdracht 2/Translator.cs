using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	internal class Translator
	{
		public Program TranslateFile(string filePath)
		{
			StreamReader sr = new StreamReader(filePath);

            return TranslateProgram(sr);
        }

		public Program TranslateProgram(StreamReader sr)
		{
            Program program = new Program();

            string line = sr.ReadLine();

            while (line != null)
            {
                /*
                while (newNestedLoops > 0)
                {
                    char indent = line[nestedLoops - 1];
                    Console.WriteLine(indent);
                    if (indent == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        newNestedLoops--;
                    }
                }
                */


                string trimmedLine = line.Trim();
                var split = trimmedLine.Split(" ");
                string task = split[0];

                switch (task)
                {
                    case "Move":
                        program.AddTask(new Move(int.Parse(split[1]))); break;
                    case "Turn":
                        program.AddTask(new Turn(split[1])); break;
                    case "Repeat":
                        program.AddTask(new Repeat(int.Parse(split[1]), TranslateProgram(sr).tasks)); break;
                }
                line = sr.ReadLine();
            }
            return program;
        }
	}
}
