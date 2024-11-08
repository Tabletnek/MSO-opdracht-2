using System;
using System.Drawing;
using MSO_Opdracht_3;

namespace TestProject1
{
	public class CalculatorTests
	{
        Calculator calc;
        TaskProgram basicProgram;
        TaskProgram advancedProgram;
        TaskProgram expertProgram;
        public CalculatorTests()
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
    }
}