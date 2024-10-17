using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
    // Defines a calculator with methods to calculate aspects of a program
    public class Calculator
    {
        // This method calculates the total number of tasks in a program
        public int numOfCommands(Program prog)
        {
            int number = 0;  // Initial amount

            // Iterate through each task in the program
            foreach (var task in prog.tasks)
            {
                number++;  // Increment for each task

                // If the task is a Repeat block, calculate the amount of tasks it contains
                if (task is Repeat)
                {
                    Repeat currentRepeat = task as Repeat;  // Cast the current task as Repeat
                    Program repeatProgram = new Program();  // Create a new program for the nested tasks

                    // Add all tasks in the Repeat block to the new program
                    foreach (var repeatTask in currentRepeat.tasks)
                        repeatProgram.tasks.Add(repeatTask);

                    // Count the commands inside the Repeat block
                    number += numOfCommands(repeatProgram);
                }
            }
            return number;  // Return total number of commands
        }

        // This method calculates the maximum nesting level of Repeat loops in the program
        public int maxNestLvl(Program prog)
        {
            int maxNumber = 0;  // Initial amount

            // Iterate through each task in the program
            foreach (var task in prog.tasks)
            {
                // If the task is a Repeat block, check the nesting level
                if (task is Repeat)
                {
                    Repeat currentRepeat = task as Repeat;  // Cast the current task as Repeat
                    Program repeatProgram = new Program();  // Create a new program for the nested tasks

                    // Add all tasks in the Repeat block to the new program
                    foreach (var repeatTask in currentRepeat.tasks)
                        repeatProgram.tasks.Add(repeatTask);

                    // Recursively calculate the nesting level
                    int currentNumber = 1 + maxNestLvl(repeatProgram);

                    // Update maxNumber if current nesting level is bigger
                    if (currentNumber > maxNumber)
                    {
                        maxNumber = currentNumber;
                    }
                }
            }
            return maxNumber;  // Return max nesting level
        }

        // This method counts the total number of Repeat blocks in a program
        public int numOfRepeats(Program prog)
        {
            int number = 0;  // Initial amount

            // Iterate through each task in the program
            foreach (var task in prog.tasks)
            {
                // If the task is a Repeat block, count it and calculate for the content of the loop
                if (task is Repeat)
                {
                    number++;  // Increment for the current Repeat block.
                    Repeat currentRepeat = task as Repeat;  // Cast the current task as Repeat
                    Program repeatProgram = new Program();  // Create a new program for the nested tasks

                    // Add all tasks in the Repeat block to the new program
                    foreach (var repeatTask in currentRepeat.tasks)
                        repeatProgram.tasks.Add(repeatTask);

                    // Count the Repeat blocks inside the current Repeat block
                    number += numOfRepeats(repeatProgram);
                }
            }
            return number;  // Return total number of Repeat blocks
        }
    }
}
