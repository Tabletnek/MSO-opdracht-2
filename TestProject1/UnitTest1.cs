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

        private bool AreTasksEqual(List<ITask> tasks1, List<ITask> tasks2)
        {
            if (tasks1.Count != tasks2.Count)
                return false;

            for (int i = 0; i < tasks1.Count; i++)
            {
                if (!AreTasksEqual(tasks1[i], tasks2[i]))
                    return false;
            }

            return true;
        }

        // Helper method to compare two ITask objects
        private bool AreTasksEqual(ITask task1, ITask task2)
        {
            if (task1 is Move move1 && task2 is Move move2)
            {
                return move1.amount == move2.amount;
            }
            else if (task1 is Turn turn1 && task2 is Turn turn2)
            {
                return turn1.direction == turn2.direction;
            }
            else if (task1 is Repeat repeat1 && task2 is Repeat repeat2)
            {
                return repeat1.amount == repeat2.amount && AreTasksEqual(repeat1.tasks, repeat2.tasks);
            }

            return false;
        }

        [Fact]
        public void ExecuteCommandTest1()
        {
            basicProgram.Run();
            Assert.Equal(new Point(10, 0), basicProgram.player.position);
            Assert.Equal("South", basicProgram.player.direction);
        }

        [Fact]
        public void ExecuteCommandTest2()
        {
            advancedProgram.Run();
            Assert.Equal(new Point(0, 0), advancedProgram.player.position);
            Assert.Equal("East", advancedProgram.player.direction);
        }

        [Fact]
        public void ExecuteCommandTest3()
        {
            expertProgram.Run();
            Assert.Equal(new Point(0, 0), expertProgram.player.position);
            Assert.Equal("East", expertProgram.player.direction);
        }

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

        [Fact]
        public void TranslatorTest1()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\basicProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
			Program transProgram = trans.TranslateFile(inputFilePath);
            //We can't just check if a task is equal, because it would just check if it is the same instance of the class of that task and that will not be the case.
            Assert.True(AreTasksEqual(basicProgram.tasks, transProgram.tasks));
        }

        [Fact]
        public void TranslatorTest2()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\advancedProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            Program transProgram = trans.TranslateFile(inputFilePath);
            //We can't just check if a task is equal, because it would just check if it is the same instance of the class of that task and that will not be the case.
            Assert.True(AreTasksEqual(advancedProgram.tasks, transProgram.tasks));
        }

        [Fact]
        public void TranslatorTest3()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\expertProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            Program transProgram = trans.TranslateFile(inputFilePath);
            //We can't just check if a task is equal, because it would just check if it is the same instance of the class of that task and that will not be the case.
            Assert.True(AreTasksEqual(expertProgram.tasks, transProgram.tasks));
        }
    }
}