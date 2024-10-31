using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_Opdracht_3
{
	//For the drag and drop system we used https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8
	//For making this class a YouTube playlist was used, https://www.youtube.com/playlist?list=PLZHx5heVfgEu45dRS8YzyNnHMRtJGWDxu
	//This playlist showed how to use a FlowLayoutPanel and it showed us how to move controls.
	//Also https://www.youtube.com/watch?app=desktop&v=VeapnO7b2gI was used.

	public class ProgramBuilder : FlowLayoutPanel
	{
		//Setting the basic properties for the ProgramBuilder
		public ProgramBuilder()
		{
			this.AllowDrop = true;
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoScroll = true; // Enable scrolling if too many panels

			this.DragEnter += OnDragEnter;
			this.DragDrop += OnDragDrop;
		}
		//Decide what to do when something is dragged over the ProgramBuilder
		private void OnDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TaskPanel)) || e.Data.GetDataPresent(typeof(RepeatPanel)))
			{
				e.Effect = DragDropEffects.Move;
			}
			else if (e.Data.GetDataPresent(DataFormats.StringFormat))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		//Handle dropping something onto the ProgramBuilder
		private void OnDragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TaskPanel)))
			{
				HandlePanelDrop<TaskPanel>(e);
			}
			else if (e.Data.GetDataPresent(typeof(RepeatPanel)))
			{
				HandlePanelDrop<RepeatPanel>(e);
			}
			else if (e.Data.GetDataPresent(DataFormats.StringFormat))
			{
				HandleTextDrop((string)e.Data.GetData(DataFormats.StringFormat));
			}
		}

		//Whenever an already existing panel is dropped again on the ProgramBuilder, rearrange the order if necessary
		private void HandlePanelDrop<T>(DragEventArgs e) where T : Control
		{
			T droppedPanel = (T)e.Data.GetData(typeof(T));
			Point dropPoint = this.PointToClient(new Point(e.X, e.Y));
			Control controlUnderMouse = this.GetChildAtPoint(dropPoint);

			if (controlUnderMouse != null && controlUnderMouse != droppedPanel)
			{
				int newIndex = this.Controls.GetChildIndex(controlUnderMouse);
				this.Controls.SetChildIndex(droppedPanel, newIndex);
			}
			else if (controlUnderMouse == null)
			{
				this.Controls.SetChildIndex(droppedPanel, this.Controls.Count - 1);
			}
		}

		//Whenever a new command is dropped using the buttons, add it to the ProgramBuilder
		private void HandleTextDrop(string text)
		{
			string input = PromptForInput(text);

			if (!string.IsNullOrEmpty(input))
			{
				if (text == "Repeat")
				{
					text += $" {input} times";
				}
				else
				{
					text += $" {input}";
				}

				AddTaskPanel(text);
			}
		}

		//Ask the user about the command they want to add to the ProgramBuilder
		private string PromptForInput(string text)
		{
			string input = string.Empty;

			switch (text)
			{
				case "Move":
					input = Interaction.InputBox("How many steps?\nType any number, e.g 5", "Move");
					if (!int.TryParse(input, out _)) return string.Empty;
					break;
				case "Turn":
					input = Interaction.InputBox("In what direction?\nType 'left' or 'right'", "Turn");
					if (input != "right" && input != "left") return string.Empty;
					break;
				case "Repeat":
					input = Interaction.InputBox("How many times?\nType any number, e.g 5", "Repeat");
					if (!int.TryParse(input, out _)) return string.Empty;
					break;
				case "RepeatUntil":
					input = Interaction.InputBox("What condition?\nType WallAhead or GridEdge", "RepeatUntil");
					if (input != "WallAhead" && input != "GridEdge") return string.Empty;
					break;
			}
			return input;
		}

		//Add a panel to the ProgramBuilder
	private void AddTaskPanel(string text)
		{
			if (text.StartsWith("Repeat"))
			{
				RepeatPanel repeatPanel = new RepeatPanel(text);
				this.Controls.Add(repeatPanel);
			}
			else
			{
				TaskPanel newPanel = new TaskPanel(text);
				this.Controls.Add(newPanel);
			}
		}

		//Load a program into the ProgramBuilder
		public void LoadProgram(TaskProgram program)
		{
			this.Controls.Clear();
			foreach (var task in program.Tasks)
			{
				AddTaskAsPanel(task);
			}
		}

		//Turn a task into a panel of the ProgramBuilder
		private void AddTaskAsPanel(ITask task)
		{
			string text = task switch
			{
				Move moveTask => $"Move {moveTask.Amount}",
				Turn turnTask => $"Turn {turnTask.Direction}",
				Repeat repeatTask => $"Repeat {repeatTask.Amount} times",
				RepeatWall => "RepeatUntil WallAhead",
				RepeatEdge => "RepeatUntil GridEdge",
				_ => null
			};

			if (!string.IsNullOrEmpty(text))
			{
				Control newPanel;
				if (text.StartsWith("Repeat"))
				{
					newPanel = new RepeatPanel(text);
				}
				else
				{
					newPanel = new TaskPanel(text);
				}
				this.Controls.Add(newPanel);
				if (task is IRepeat repeatableTask)
					AddTasksToRepeatPanel((RepeatPanel)newPanel, repeatableTask.Tasks);
			}
		}

		// Recursively add tasks to a RepeatPanel
		private void AddTasksToRepeatPanel(RepeatPanel repeatPanel, List<ITask> tasks)
		{
			foreach (var task in tasks)
			{
				string text = task switch
				{
					Move moveTask => $"Move {moveTask.Amount}",
					Turn turnTask => $"Turn {turnTask.Direction}",
					Repeat nestedRepeatTask => $"Repeat {nestedRepeatTask.Amount} times",
					RepeatWall => "RepeatUntil WallAhead",
					RepeatEdge => "RepeatUntil GridEdge",
					_ => null
				};

				if (text != null)
				{
					Control newPanel;
					if (text.StartsWith("Repeat"))
					{
						newPanel = new RepeatPanel(text);
					}
					else
					{
						newPanel = new TaskPanel(text);
					}
					newPanel.Margin = new Padding(20, 5, 0, 0);
					if (newPanel is RepeatPanel nestedRepeatPanel)
					{
						nestedRepeatPanel.Margin = new Padding(20, 5, 0, 0);
						AddTasksToRepeatPanel(nestedRepeatPanel, ((IRepeat)task).Tasks);
					}
					repeatPanel.Controls.Add(newPanel);
				}
			}
		}
	}
}
