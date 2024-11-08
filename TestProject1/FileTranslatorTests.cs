using System;
using System.Drawing;
using MSO_Opdracht_3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TestProject1
{
	public class FileTranslatorTests
	{
        private TranslatorContext translatorContext;
        private TaskProgram basicProgram;
        private TaskProgram advancedProgram;
        private TaskProgram expertProgram;
        private TaskProgram moveProgram;
        private TaskProgram repeatUntilProgram;
        public FileTranslatorTests()
        {
            translatorContext = new TranslatorContext();

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
            // If both tasks are RepeatEdge tasks, compare the repetition amount and compare the sub-tasks
            else if (task1 is RepeatEdge repeatEdge1 && task2 is RepeatEdge repeatEdge2)
            {
                return AreTasksEqual(repeatEdge1.Tasks, repeatEdge2.Tasks);
            }

            return false;  // If the tasks are of different types or not equal
        }

        // Test for translating a text file into a program
        [Fact]
        public void TranslatorTest1()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\basicProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new FileTranslator(inputFilePath));
            TaskProgram transProgram = translatorContext.ExecuteTranslation<TaskProgram>();
            Assert.True(AreTasksEqual(basicProgram.Tasks, transProgram.Tasks));  // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest2()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\advancedProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new FileTranslator(inputFilePath));
            TaskProgram transProgram = translatorContext.ExecuteTranslation<TaskProgram>();
            Assert.True(AreTasksEqual(advancedProgram.Tasks, transProgram.Tasks));  // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest3()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\expertProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new FileTranslator(inputFilePath));
            TaskProgram transProgram = translatorContext.ExecuteTranslation<TaskProgram>();
            Assert.True(AreTasksEqual(expertProgram.Tasks, transProgram.Tasks));  // Compare tasks after translation
        }

        [Fact]
        public void TranslatorTest4()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\Programs\repeatUntilProgram.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new FileTranslator(inputFilePath));
            TaskProgram transProgram = translatorContext.ExecuteTranslation<TaskProgram>();
            Assert.True(AreTasksEqual(repeatUntilProgram.Tasks, transProgram.Tasks));  // Compare tasks after translation
        }
    }
}