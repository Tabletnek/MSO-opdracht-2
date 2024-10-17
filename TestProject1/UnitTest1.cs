using MSO_opdracht_2;

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


        [Fact]
        public void numOfCommandsTest1()
        {
            Assert.Equal(2, calc.numOfCommands(basicProgram));
        }

        [Fact]
        public void numOfCommandsTest2()
        {
            Assert.Equal(3, calc.numOfCommands(advancedProgram));
        }

        [Fact]
        public void numOfCommandsTest3()
        {
            Assert.Equal(4, calc.numOfCommands(expertProgram));
        }

        [Fact]
        public void maxNestLvlTest1()
        {
            Assert.Equal(0, calc.maxNestLvl(basicProgram));
        }

        [Fact]
		public void maxNestLvlTest2()
		{
            Assert.Equal(1, calc.maxNestLvl(advancedProgram));
        }

        [Fact]
        public void maxNestLvlTest3()
        {
            Assert.Equal(2, calc.maxNestLvl(expertProgram));
        }

        [Fact]
        public void numOfRepeatsTest1()
        {
            Assert.Equal(0, calc.numOfRepeats(basicProgram));
        }

        [Fact]
        public void numOfRepeatsTest2()
        {
            Assert.Equal(1, calc.numOfRepeats(advancedProgram));
        }

        [Fact]
        public void numOfRepeatsTest3()
        {
            Assert.Equal(2, calc.numOfRepeats(expertProgram));
        }

        [Fact]
        public void translatorTest1()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 2\basicProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
			Program transProgram = trans.TranslateFile(inputFilePath);
            //We can't just check if a task is equal, because it would just check if it is the same instance of the class of that task and that will not be the case.
			Assert.Equal(basicProgram.tasks.Count, transProgram.tasks.Count);

            //We need to check if the individual elements are the same
			Assert.Collection(transProgram.tasks,
				task => {
					var moveTask = Assert.IsType<Move>(task);
					Assert.Equal(10, moveTask.amount);
				},
				task => {
					var turnTask = Assert.IsType<Turn>(task);
					Assert.Equal("right", turnTask.direction);
				}
			);
		}
    }
}