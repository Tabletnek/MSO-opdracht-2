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
			this.DragEnter += FlowLayoutPanel1_DragEnter;
			this.DragDrop += FlowLayoutPanel1_DragDrop;
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoScroll = true; // Enable scrolling if too many panels
		}

		private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Panel)) || e.Data.GetDataPresent(typeof(RepeatPanel)))
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
			if (e.Data.GetDataPresent(typeof(Panel)))
			{
				Panel droppedPanel = (Panel)e.Data.GetData(typeof(Panel));
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
				Panel newPanel = new Panel
				{
					Size = new Size(400, 80),
					BackColor = Color.MediumPurple,
					BorderStyle = BorderStyle.FixedSingle
				};

				newPanel.MouseDown += MouseDown;

				Label taskLabel = new Label
				{
					Text = text,
					Font = new Font("Segoe UI", 15F),
					ForeColor = Color.White,
					BackColor = Color.Transparent,
					AutoSize = true,
					Dock = DockStyle.None,
					Location = new Point(10, 10),
					Padding = new Padding(5)
				};

				Button removeButton = new Button
				{
					Size = new Size(30, 20),
					Text = "X",
					Dock = DockStyle.Right,
					BackColor = Color.Red,
					ForeColor = Color.White,
					Visible = true
				};

				removeButton.Click += (s, e) =>
				{
					newPanel.Parent.Controls.Remove(newPanel);
				};

				newPanel.Controls.Add(taskLabel);
				newPanel.Controls.Add(removeButton);

				this.Controls.Add(newPanel);
			}
		}

		private void MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.DoDragDrop((Panel)sender, DragDropEffects.Move);
			}
		}
	}
}
