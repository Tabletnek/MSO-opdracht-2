using MSO_opdracht_2;
using System.Drawing;

namespace TestProject1
{
	public class UnitTest1
	{
        Calculator calc;
        Translator trans;
        Program basicProgram;
        Program advancedProgram;
        Program expertProgram;
        public UnitTest1()
        {
            calc = new Calculator();
            trans = new Translator();

            basicProgram = new Program();
            basicProgram.AddTask(new Move(10));
            basicProgram.AddTask(new Turn("right"));

            advancedProgram = new Program();
            advancedProgram.AddTask(new Repeat(4, basicProgram.tasks));

            expertProgram = new Program();
            expertProgram.AddTask(new Repeat(3, advancedProgram.tasks));
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
                return move1.amount == move2.amount;
            }

            // If both tasks are Turn tasks, compare the direction
            else if (task1 is Turn turn1 && task2 is Turn turn2)
            {
                return turn1.direction == turn2.direction;
            }
            // If both tasks are Repeat tasks, compare the repetition amount and compare the sub-tasks
            else if (task1 is Repeat repeat1 && task2 is Repeat repeat2)
            {
                return repeat1.amount == repeat2.amount && AreTasksEqual(repeat1.tasks, repeat2.tasks);
            }

            return false;  // If the tasks are of different types or not equal
        }

        // Test for program execution, checking final player position and direction
        [Fact]
        public void ExecuteCommandTest1()
        {
            basicProgram.Run();
            Assert.Equal(new Point(10, 0), basicProgram.player.position);  // Check if player moved correctly
            Assert.Equal("South", basicProgram.player.direction);  // Check if player turned correctly
        }

        [Fact]
        public void ExecuteCommandTest2()
        {
            advancedProgram.Run();
            Assert.Equal(new Point(0, 0), advancedProgram.player.position); // Check if player moved correctly
            Assert.Equal("East", advancedProgram.player.direction); // Check if player turned correctly
        }

        [Fact]
        public void ExecuteCommandTest3()
        {
            expertProgram.Run();
            Assert.Equal(new Point(0, 0), expertProgram.player.position); // Check if player turned correctly
            Assert.Equal("East", expertProgram.player.direction); // Check if player turned correctly
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
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\basicProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            Program transProgram = trans.TranslateFile(inputFilePath);
            Assert.True(AreTasksEqual(basicProgram.tasks, transProgram.tasks));  // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest2()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\advancedProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            Program transProgram = trans.TranslateFile(inputFilePath);
            Assert.True(AreTasksEqual(advancedProgram.tasks, transProgram.tasks)); // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest3()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\expertProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            Program transProgram = trans.TranslateFile(inputFilePath);
            Assert.True(AreTasksEqual(expertProgram.tasks, transProgram.tasks)); // Compare tasks after translation
        }
    }
}