using System.IO;

namespace MSO_Opdracht_3
{
    // The Translator class translates a text file to a program
    public class FileTranslator : ITranslator<TaskProgram>
    {
        private readonly string _filePath;
        private string _line; // A line from the text file
        private int _size;

        public FileTranslator(string _filePath)
        {
            this._filePath = _filePath;
        }

        // This method starts the StreamReader and initializes the translation process
        public TaskProgram Translate()
        {
            using StreamReader sr = new StreamReader(_filePath);
            _line = sr.ReadLine();
            var splitFirstLine = _line.Split(" ");
            _size = int.Parse(splitFirstLine[1]);
            _line = sr.ReadLine();
            return TranslateProgram(sr, 0);
        }

        // Creates a new program, which is used when initially translating a file and for using Repeat
        private TaskProgram TranslateProgram(StreamReader sr, int nestedLoops)
        {
            TaskProgram program = new TaskProgram(_size);
            while (_line != null)
            {
                if (nestedLoops > 0) // If we're in a Repeat loop, the amount of nestedLoops is larger than 0
                {
                    char indent = _line[nestedLoops - 1]; // This checks if the level of indentation matches how nested the loop is
                    if (indent != '\t')                  // If it isn't, we exit the current loop
                    {
                        return program;                  // We don't move on to the next line when we exit the loop.                                
                    }                                    // That's because we haven't added the task of our current line yet 
                }
                string trimmedLine = _line.Trim(); // Read the line without any indentation
                var split = trimmedLine.Split(" ");
                string task = split[0];  // Reads the task
                _line = sr.ReadLine();    // Ready the next line before adding the current task. If we don't, the method will use the old line when adding a new Repeat loop
                switch (task)
                {
                    case "Move":
                        program.AddTask(new Move(int.Parse(split[1]))); break;
                    case "Turn":
                        program.AddTask(new Turn(split[1])); break;
                    case "Repeat":
                        program.AddTask(new Repeat(int.Parse(split[1]), TranslateProgram(sr, nestedLoops + 1).Tasks)); break; // Creates a new program to use for our loop
                    case "RepeatUntil":
                        string condition = split[1];
                        switch (condition)
                        {
                            case "WallAhead":
                                program.AddTask(new RepeatWall(TranslateProgram(sr, nestedLoops + 1).Tasks)); break; // Creates a new program to use for our loop
                            case "GridEdge":
                                program.AddTask(new RepeatEdge(TranslateProgram(sr, nestedLoops + 1).Tasks)); break; // Creates a new program to use for our loop
                        }
                        break;
                }
            }
            return program;  // If we reached the end of the text file, we return the program
        }
    }
}
