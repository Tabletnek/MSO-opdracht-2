using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
    // The Translator class translates a text file to a program
    public class PathTranslator
    {
        string line; // A line from the text file
        int size;

        // This method starts the StreamReader and initializes the translation process
        public PathFindingGrid TranslateFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            line = sr.ReadLine();
            size = line.Length;
            return TranslateExercise(sr);
        }

        // Creates a new exercise
        public PathFindingGrid TranslateExercise(StreamReader sr)
        {
            PathFindingGrid grid = new PathFindingGrid(size);
            int row = size;
            while (line != null)
            {
                row--;
                for (int i = 0; i < size; i++)
                {
                    char tile = line[i];
                    if (tile == '+')
                    {
                        grid.walls.Add(new Point(i, row));
                    }
                }
                line = sr.ReadLine();
            }
            return grid;  // If we reached the end of the text file, we return the grid
        }
    }
}
