﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
    internal class Translator
    {
        string line;
        public Program TranslateFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            line = sr.ReadLine();

            return TranslateProgram(sr, 0);
        }

        public Program TranslateProgram(StreamReader sr, int nestedLoops)
        {
            Program program = new Program();
            while (line != null)
            {
                if (nestedLoops > 0)
                {
                    char indent = line[nestedLoops - 1];
                    if (indent != '\t')
                    {
                        return program;
                    }
                }
                string trimmedLine = line.Trim();
                var split = trimmedLine.Split(" ");
                string task = split[0];
                line = sr.ReadLine();
                switch (task)
                {
                    case "Move":
                        program.AddTask(new Move(int.Parse(split[1]))); break;
                    case "Turn":
                        program.AddTask(new Turn(split[1])); break;
                    case "Repeat":
                        program.AddTask(new Repeat(int.Parse(split[1]), TranslateProgram(sr, nestedLoops + 1).tasks)); break;
                }
            }
            return program;
        }
    }
}
