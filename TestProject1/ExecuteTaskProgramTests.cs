using System;
using System.Drawing;
using MSO_Opdracht_3;

namespace TestProject1
{
    public class ExecuteTaskProgramTests
    {
        private TaskProgram basicProgram;
        private TaskProgram advancedProgram;
        private TaskProgram expertProgram;
        private TaskProgram moveProgram;
        private TaskProgram repeatUntilProgram;

        public ExecuteTaskProgramTests()
        {
            basicProgram = new TaskProgram(0);
            basicProgram.AddTask(new Move(10));
            basicProgram.AddTask(new Turn("left"));

            advancedProgram = new TaskProgram(0);
            advancedProgram.AddTask(new Repeat(4, basicProgram.Tasks));

            expertProgram = new TaskProgram(0);
            expertProgram.AddTask(new Repeat(3, advancedProgram.Tasks));

            // Create program to use for repeatUntil
            moveProgram = new TaskProgram(0);
            moveProgram.AddTask(new Move(1));

            repeatUntilProgram = new TaskProgram(5);
            repeatUntilProgram.AddTask(new RepeatEdge(moveProgram.Tasks));
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
            Assert.Equal(new Point(0, 0), expertProgram.Player.Position); // Check if player moved correctly
            Assert.Equal("East", expertProgram.Player.Direction); // Check if player turned correctly
        }

        [Fact]
        public void ExecuteCommandTest4()
        {
            repeatUntilProgram.Run();
            Assert.Equal(new Point(4, 0), repeatUntilProgram.Player.Position); // Check if player moved correctly
            Assert.Equal("East", repeatUntilProgram.Player.Direction); // Check if player turned correctly
        }
    }
}