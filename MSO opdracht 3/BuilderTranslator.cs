namespace MSO_Opdracht_3
{
    public class BuilderTranslator : ITranslator<TaskProgram>
    {
        private readonly ProgramBuilder _programBuilder;
        private readonly int _programSize;

        public BuilderTranslator(ProgramBuilder programBuilder, int programSize)
        {
            this._programBuilder = programBuilder;
            this._programSize = programSize;
        }

        // Implementing Translate to match the ITranslator<TaskProgram> interface
        public TaskProgram Translate()
        {
            var program = new TaskProgram(_programSize);
            TranslateControls(_programBuilder.Controls, program);
            return program;
        }

        private void TranslateControls(Control.ControlCollection controls, TaskProgram program)
        {
            foreach (Control control in controls)
            {
                if (control is Panel taskPanel && !(control is RepeatPanel))
                {
                    var task = CreateTaskFromPanel(taskPanel);
                    if (task != null)
                    {
                        program.AddTask(task);
                    }
                }
                else if (control is RepeatPanel repeatPanel)
                {
                    var repeatTask = CreateRepeatTaskFromPanel(repeatPanel, program.Grid.Size);
                    if (repeatTask != null)
                    {
                        program.AddTask(repeatTask);
                    }
                }
            }
        }

        private ITask CreateTaskFromPanel(Panel panel)
        {
            var labelText = (panel.Controls[0] as Label).Text;
            var splitText = labelText.Split(' ');
            string taskType = splitText[0];

            switch (taskType)
            {
                case "Move":
                    if (int.TryParse(splitText[1], out int moveSteps))
                    {
                        return new Move(moveSteps);
                    }
                    break;

                case "Turn":
                    if (splitText[1] == "left" || splitText[1] == "right")
                    {
                        return new Turn(splitText[1]);
                    }
                    break;
            }
            return null;
        }

        private ITask CreateRepeatTaskFromPanel(RepeatPanel repeatPanel, int programSize)
        {
            string labelText = (repeatPanel.Controls[0] as Label).Text;
            var splitText = labelText.Split(' ');
            var nestedProgram = new TaskProgram(programSize);
            string repeatType = splitText[0];

            TranslateControls(repeatPanel.Controls, nestedProgram);

            switch (repeatType)
            {
                case "Repeat":
                    if (int.TryParse(splitText[1], out int repeatCount))
                    {
                        return new Repeat(repeatCount, nestedProgram.Tasks);
                    }
                    break;

                case "RepeatUntil":
                    string condition = splitText[1];
                    return condition switch
                    {
                        "WallAhead" => new RepeatWall(nestedProgram.Tasks),
                        "GridEdge" => new RepeatEdge(nestedProgram.Tasks),
                        _ => null
                    };
            }

            return null;
        }
    }
}
