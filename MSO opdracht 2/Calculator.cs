using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
	internal class Calculator
	{
		public int numOfCommands(Program prog)
		{
			return prog.tasks.Count;
		}

		public int maxNestLvl(Program prog)
		{
			return 0;
		}

		public int numOfRepeat(Program prog)
		{
			int number = 0;
			foreach (var task in prog.tasks) 
			{
				if (task is Repeat)
					number += 1;
			}
			return number;
		}
	}
}
