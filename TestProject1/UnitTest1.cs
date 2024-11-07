using System;
using System.Drawing;
using MSO_Opdracht_3;

namespace TestProject1
{
	public class UnitTest1
	{
        Calculator calc;
        FileTranslator fileTrans;
        TaskProgram basicProgram;
        TaskProgram advancedProgram;
        TaskProgram expertProgram;
        public UnitTest1()
        {
            calc = new Calculator();

            basicProgram = new TaskProgram(0);
            basicProgram.AddTask(new Move(10));
            basicProgram.AddTask(new Turn("left"));

            advancedProgram = new TaskProgram(0);
            advancedProgram.AddTask(new Repeat(4, basicProgram.Tasks));

            expertProgram = new TaskProgram(0);
            expertProgram.AddTask(new Repeat(3, advancedProgram.Tasks));
        }

        // We can't just check if two methods are equal with Assert.Equal, because it would just check if they are the same instance and that will not be the case.
        // Therefore we have a custom method to compare two lists of tasks, which uses a custom method to compare two tasks.

        // Compares two lists of tasks
        private bool AreTasksEqual(List<ITask> tasks1, List<ITask> tasks2)
        {
            // Check if the number of tasks in both lists is the same
            if (tasks1.Count != tasks2.Count)
                return false;

            // Compare each task in both lists
            for (int i = 0; i < tasks1.Count; i++)
            {
                if (!AreTasksEqual(tasks1[i], tasks2[i]))  // Use AreTasksEqual to compare individual tasks
                    return false;                          // Return false if any tasks are not equal
            }

            return true; // All tasks are equal
        }

        // Compares two tasks
        private bool AreTasksEqual(ITask task1, ITask task2)
        {
            // If both tasks are Move tasks, compare the movement amount
            if (task1 is Move move1 && task2 is Move move2)
            {
                return move1.Amount == move2.Amount;
            }

            // If both tasks are Turn tasks, compare the direction
            else if (task1 is Turn turn1 && task2 is Turn turn2)
            {
                return turn1.Direction == turn2.Direction;
            }
            // If both tasks are Repeat tasks, compare the repetition amount and compare the sub-tasks
            else if (task1 is Repeat repeat1 && task2 is Repeat repeat2)
            {
                return repeat1.Amount == repeat2.Amount && AreTasksEqual(repeat1.Tasks, repeat2.Tasks);
            }

            return false;  // If the tasks are of different types or not equal
        }

        // Test for program execution, checking final player position and direction
        [Fact]
        public void ExecuteCommandTest1()
        {
            basicProgram.Run();
            Assert.Equal(new Point(10, 0), basicProgram.Player.Position);  // Check if player moved correctly
            Assert.Equal("North", basicProgram.Player.Direction);  // Check if player turned correctly
        }

        [Fact]
        public void ExecuteCommandTest2()
        {
            advancedProgram.Run();
            Assert.Equal(new Point(0, 0), advancedProgram.Player.Position); // Check if player moved correctly
            Assert.Equal("East", advancedProgram.Player.Direction); // Check if player turned correctly
        }

        [Fact]
        public void ExecuteCommandTest3()
        {
            expertProgram.Run();
            Assert.Equal(new Point(0, 0), expertProgram.Player.Position); // Check if player turned correctly
            Assert.Equal("East", expertProgram.Player.Direction); // Check if player turned correctly
        }

        // Test for counting the commands of a program
        [Fact]
        public void NumOfCommandsTest1()
        {
            Assert.Equal(2, calc.numOfCommands(basicProgram));  
        }

        [Fact]
        public void NumOfCommandsTest2()
        {
            Assert.Equal(3, calc.numOfCommands(advancedProgram));
        }

        [Fact]
        public void NumOfCommandsTest3()
        {
            Assert.Equal(4, calc.numOfCommands(expertProgram));
        }

        // Test for max nesting level in a program.
        [Fact]
        public void MaxNestLvlTest1()
        {
            Assert.Equal(0, calc.maxNestLvl(basicProgram));  
        }

        [Fact]
        public void MaxNestLvlTest2()
        {
            Assert.Equal(1, calc.maxNestLvl(advancedProgram));
        }

        [Fact]
        public void MaxNestLvlTest3()
        {
            Assert.Equal(2, calc.maxNestLvl(expertProgram));
        }

        // Test for counting Repeat tasks in a program
        [Fact]
        public void NumOfRepeatsTest1()
        {
            Assert.Equal(0, calc.numOfRepeats(basicProgram));  
        }

        [Fact]
        public void NumOfRepeatsTest2()
        {
            Assert.Equal(1, calc.numOfRepeats(advancedProgram));
        }

        [Fact]
        public void NumOfRepeatsTest3()
        {
            Assert.Equal(2, calc.numOfRepeats(expertProgram));
        }

        // Test for translating a text file into a program
        [Fact]
        public void TranslatorTest1()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\basicProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
			fileTrans = new FileTranslator(inputFilePath);
			TaskProgram transProgram = fileTrans.Translate(); 
			Assert.True(AreTasksEqual(basicProgram.Tasks, transProgram.Tasks));  // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest2()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\advancedProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            fileTrans = new FileTranslator(inputFilePath);
            TaskProgram transProgram = fileTrans.Translate();
            Assert.True(AreTasksEqual(advancedProgram.Tasks, transProgram.Tasks)); // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest3()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\expertProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
			fileTrans = new FileTranslator(inputFilePath);
			TaskProgram transProgram = fileTrans.Translate();
			Assert.True(AreTasksEqual(expertProgram.Tasks, transProgram.Tasks)); // Compare tasks after translation
        }
    }
}