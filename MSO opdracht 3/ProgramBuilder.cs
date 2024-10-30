using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	//For the drag and drop system we used https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8
	//For making this class a YouTube playlist was used, https://www.youtube.com/playlist?list=PLZHx5heVfgEu45dRS8YzyNnHMRtJGWDxu
	//This playlist showed how to use a FlowLayoutPanel and it showed us how to move controls.
	//Also https://www.youtube.com/watch?app=desktop&v=VeapnO7b2gI was used.

	public class ProgramBuilder : FlowLayoutPanel
	{
		public ProgramBuilder()
		{
			this.AllowDrop = true;
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoScroll = true; // Enable scrolling if too many panels

			this.DragEnter += FlowLayoutPanel1_DragEnter;
			this.DragDrop += FlowLayoutPanel1_DragDrop;
		}

		private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
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

		private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TaskPanel)))
			{
				TaskPanel droppedPanel = (TaskPanel)e.Data.GetData(typeof(TaskPanel));
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
			else if (e.Data.GetDataPresent(typeof(RepeatPanel)))
			{
				RepeatPanel droppedPanel = (RepeatPanel)e.Data.GetData(typeof(RepeatPanel));
				Point dropPoint = this.PointToClient(new Point(e.X, e.Y));
				Control controlUnderMouse = this.GetChildAtPoint(dropPoint);

				// Check if the panel should be rearranged
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
			else if (e.Data.GetDataPresent(DataFormats.StringFormat))
			{
				string text = (string)e.Data.GetData(DataFormats.StringFormat);
				string input;

				switch (text)
				{
					case "Move":
						input = Interaction.InputBox("How many steps?\nType any number, e.g 5", "Move");
						if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int moveNumber))
							text += $" {moveNumber}";
						else return;
						break;
					case "Turn":
						input = Interaction.InputBox("In what direction?\nType 'left' or 'right'", "Turn");
						if (!string.IsNullOrEmpty(input) && (input == "right" || input == "left"))
							text += $" {input}";
						else return;
						break;
					case "Repeat":
						input = Interaction.InputBox("How many times?\nType any number, e.g 5", "Repeat");
						if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int repeatNumber))
							text += $" {repeatNumber} times";
						else return;
						break;
					case "RepeatUntil":
						input = Interaction.InputBox("What condition?\nType WallAhead or GridEdge", "RepeatUntil");
						if (!string.IsNullOrEmpty(input) && (input == "WallAhead" || input == "GridEdge"))
							text += $" {input}";
						else return;
						break;
				}

				AddTaskPanel(text); // Add a new task panel based on the dragged text
			}
		}

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

		public void LoadProgram(TaskProgram program)
		{
			this.Controls.Clear();
			foreach (var task in program.tasks)
			{
				AddTaskAsPanel(task);
			}
		}

		private void AddTaskAsPanel(ITask task)
		{
			switch (task)
			{
				case Move moveTask:
					AddTaskPanel($"Move {moveTask.amount}");
					break;
				case Turn turnTask:
					AddTaskPanel($"Turn {turnTask.direction}");
					break;
				case Repeat repeatTask:
					var repeatPanel = new RepeatPanel($"Repeat {repeatTask.amount} times");
					this.Controls.Add(repeatPanel);
					AddTasksToRepeatPanel(repeatPanel, repeatTask.tasks);
					break;
				case RepeatWall repeatWallTask:
					var repeatWallPanel = new RepeatPanel("RepeatUntil WallAhead");
					this.Controls.Add(repeatWallPanel);
					AddTasksToRepeatPanel(repeatWallPanel, repeatWallTask.tasks);
					break;
				case RepeatEdge repeatEdgeTask:
					var repeatEdgePanel = new RepeatPanel("RepeatUntil GridEdge");
					this.Controls.Add(repeatEdgePanel);
					AddTasksToRepeatPanel(repeatEdgePanel, repeatEdgeTask.tasks);
					break;
			}
		}

		// New method to recursively add tasks to a RepeatPanel
		private void AddTasksToRepeatPanel(RepeatPanel repeatPanel, List<ITask> tasks)
		{
			foreach (var task in tasks)
			{
				switch (task)
				{
					case Move moveTask:
						repeatPanel.AddTaskPanel($"Move {moveTask.amount}"); // Add Move tasks directly to repeat panel
						break;

					case Turn turnTask:
						repeatPanel.AddTaskPanel($"Turn {turnTask.direction}"); // Add Turn tasks directly to repeat panel
						break;

					case Repeat nestedRepeatTask:
						var nestedRepeatPanel = new RepeatPanel($"Repeat {nestedRepeatTask.amount} times");
						nestedRepeatPanel.Margin = new Padding(20 , 5, 0, 0); 
						repeatPanel.Controls.Add(nestedRepeatPanel); // Add the nested repeat panel
						AddTasksToRepeatPanel(nestedRepeatPanel, nestedRepeatTask.tasks);
						break;

					case RepeatWall nestedRepeatWallTask:
						var nestedRepeatWallPanel = new RepeatPanel("RepeatUntil WallAhead");
						nestedRepeatWallPanel.Margin = new Padding(20, 5, 0, 0);
						repeatPanel.Controls.Add(nestedRepeatWallPanel); // Add the nested repeat wall panel
						AddTasksToRepeatPanel(nestedRepeatWallPanel, nestedRepeatWallTask.tasks);
						break;

					case RepeatEdge nestedRepeatEdgeTask:
						var nestedRepeatEdgePanel = new RepeatPanel("RepeatUntil GridEdge");
						nestedRepeatEdgePanel.Margin = new Padding(20, 5, 0, 0);
						repeatPanel.Controls.Add(nestedRepeatEdgePanel); // Add the nested repeat edge panel
						AddTasksToRepeatPanel(nestedRepeatEdgePanel, nestedRepeatEdgeTask.tasks);
						break;
				}
			}
		}
	}
}
