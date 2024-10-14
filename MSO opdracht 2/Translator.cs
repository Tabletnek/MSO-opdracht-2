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
		public Program Translate(string filePath)
		{
			StreamReader sr = new StreamReader(filePath);
			Program program = new Program();

			string line = sr.ReadLine();

			while (line != null)
			{
				var split = line.Split(" ");
				string task = split[0];

				switch (task)
				{
					case "Move":
						program.AddTask(new Move(int.Parse(split[1]))); break;
					case "Turn":
						program.AddTask(new Turn(split[1])); break;
				}
				line = sr.ReadLine();
			}
			return program;
		}
	}
}
