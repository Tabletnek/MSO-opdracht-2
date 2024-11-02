using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
    // The Translator class translates a text file to a grid
    public class PathTranslator : ITranslator<PathFindingGrid>
    {
        private readonly string _filePath;
        private string _line; // A line from the text file
        private int _size;

        public PathTranslator(string _filePath)
        {
            this._filePath = _filePath;
        }

        // This method starts the StreamReader and initializes the translation process
        public PathFindingGrid Translate()
        {
            using StreamReader sr = new StreamReader(_filePath);
            _line = sr.ReadLine();
            _size = _line.Length;
            return TranslateExercise(sr);
        }

        // Creates a new exercise
        private PathFindingGrid TranslateExercise(StreamReader sr)
        {
            PathFindingGrid grid = new PathFindingGrid(_size);
            int row = _size;
            while (_line != null)
            {
                row--;
                for (int i = 0; i < _size; i++)
                {
                    char tile = _line[i];
                    if (tile == '+')
                    {
                        grid.Walls.Add(new Point(i, row));
                    }
                    if (tile == 'x')
                    {
                        grid.EndPoint = new Point(i, row);
                    }
                }
                _line = sr.ReadLine();
            }
            return grid;  // If we reached the end of the text file, we return the grid
        }
    }
}
