using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	public class Calculator
	{
		public int numOfCommands(Program prog)
		{
			int number = 0;
			foreach (var task in prog.tasks)
			{
				number++;
				if (task is Repeat)
				{
					Repeat currentRepeat = task as Repeat;
					Program repeatProgram = new Program();

					foreach (var repeatTask in currentRepeat.tasks)
						repeatProgram.tasks.Add(repeatTask);

					number += numOfCommands(repeatProgram);
				}
			}
			return number;
		}

		public int maxNestLvl(Program prog)
		{
			int maxNumber = 0;
			foreach (var task in prog.tasks)
			{
				if (task is Repeat)
				{
					Repeat currentRepeat = task as Repeat;
					Program repeatProgram = new Program();

					foreach (var repeatTask in currentRepeat.tasks)
						repeatProgram.tasks.Add(repeatTask);

					int currentNumber = 1 + maxNestLvl(repeatProgram);

					if (currentNumber > maxNumber)
					{
						maxNumber = currentNumber;
					}
				}
			}
			return maxNumber;
		}

		public int numOfRepeats(Program prog)
		{
			int number = 0;
			foreach (var task in prog.tasks)
			{
				if (task is Repeat)
				{
					number++;
					Repeat currentRepeat = task as Repeat;
					Program repeatProgram = new Program();

					foreach (var repeatTask in currentRepeat.tasks)
						repeatProgram.tasks.Add(repeatTask);

					number += numOfRepeats(repeatProgram);
				}
			}
			return number;
		}
	}
}
