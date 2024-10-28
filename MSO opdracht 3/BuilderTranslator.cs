using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSO_opdracht_3
{
	public class BuilderTranslator
	{

		public TaskProgram TranslateBuilder(ProgramBuilder programBuilder, int programSize)
		{
			var program = new TaskProgram(programSize);
			TranslateControls(programBuilder.Controls, program);
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
					var repeatTask = CreateRepeatTaskFromPanel(repeatPanel, program.board.size);
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
			if (splitText[0] == "Repeat")
			{
				if (int.TryParse(splitText[1], out int repeatCount))
				{
					var nestedProgram = new TaskProgram(programSize);
					TranslateControls(repeatPanel.Controls, nestedProgram);
					return new Repeat(repeatCount, nestedProgram.tasks);
				}
			}
			else if (splitText[0] == "RepeatUntil")
			{
				var condition = splitText[1];
				var nestedProgram = new TaskProgram(programSize);
				TranslateControls(repeatPanel.Controls, nestedProgram);

				return condition switch
				{
					"WallAhead" => new RepeatWall(nestedProgram.tasks),
					"GridEdge" => new RepeatEdge(nestedProgram.tasks),
					_ => null
				};
			}
			return null;
		}
	}
}
