using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using MSO_Opdracht_3;

namespace TestProject1
{
	public class PathTranslatorTests
	{
        private TranslatorContext translatorContext;
        private PathFindingGrid basicExercise;
        private PathFindingGrid advancedExercise;
        private PathFindingGrid expertExercise;
        public PathTranslatorTests()
        {
            translatorContext = new TranslatorContext();

            basicExercise = new PathFindingGrid(5);
            advancedExercise = new PathFindingGrid(3);
            expertExercise = new PathFindingGrid(5);

            basicExercise.EndPoint = new Point(4, 0);
            advancedExercise.EndPoint = new Point(2, 0);
            advancedExercise.AddWall(new Point(1, 1));
            advancedExercise.AddWall(new Point(2, 1));
            expertExercise.EndPoint = new Point(2, 2);
            expertExercise.AddWall(new Point(2, 3));
            expertExercise.AddWall(new Point(1, 2));
            expertExercise.AddWall(new Point(3, 2));
        }

        // We can't just check if two exercises are equal with Assert.Equal, because it would just check if they are the same instance and that will not be the case.
        // Therefore we have a custom method to compare exercises
        private bool AreExercisesEqual(PathFindingGrid exercise1, PathFindingGrid exercise2)
        {
            if (exercise1.Size != exercise2.Size)
                return false;

            if (exercise1.EndPoint != exercise2.EndPoint)
                return false;

            if (exercise1.Walls.Count != exercise2.Walls.Count)
                return false;

            for (int i = 0; i < exercise1.Walls.Count; i++)
            {
                if (exercise1.Walls[i] != exercise2.Walls[i])  
                    return false;                        
            }

            return true; 
        }


        // Test for translating a text file into an exercise
        [Fact]
        public void TranslatorTest1()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\TestExercises\basicExercise.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new PathTranslator(inputFilePath));
            PathFindingGrid transExercise = translatorContext.ExecuteTranslation<PathFindingGrid>();
            Assert.True(AreExercisesEqual(basicExercise, transExercise));  // Compare exercises after translation
        }

        [Fact]
        public void TranslatorTest2()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\TestExercises\advancedExercise.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new PathTranslator(inputFilePath));
            PathFindingGrid transExercise = translatorContext.ExecuteTranslation<PathFindingGrid>();
            Assert.True(AreExercisesEqual(advancedExercise, transExercise));  // Compare exercises after translation
        }

        [Fact]
        public void TranslatorTest3()
        {
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"MSO opdracht 3\TestExercises\expertExercise.txt");
            inputFilePath = Path.GetFullPath(inputFilePath);
            translatorContext.SetTranslator(new PathTranslator(inputFilePath));
            PathFindingGrid transExercise = translatorContext.ExecuteTranslation<PathFindingGrid>();
            Assert.True(AreExercisesEqual(expertExercise, transExercise));  // Compare exercises after translation
        }
    }
}