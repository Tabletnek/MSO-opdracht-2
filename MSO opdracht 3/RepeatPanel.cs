using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSO_Opdracht_3
{
	public class RepeatPanel : FlowLayoutPanel
	{
		private readonly Label _repeatLabel;

		public RepeatPanel(string text)
		{
			this.MinimumSize = new Size(400, 80);
			this.BackColor = Color.Purple;
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoSize = true;
			this.AllowDrop = true;

			this.MouseDown += OnMouseDown;
			this.DragEnter += OnDragEnter;
			this.DragDrop += OnDragDrop;

			_repeatLabel = CreateRepeatLabel(text);

			Button removeButton = CreateRemoveButton();

			this.Controls.Add(_repeatLabel);
			this.Controls.Add(removeButton);
  
		}

		public Label CreateRepeatLabel(string text)
		{
			Label repeatLabel = new Label
			{
				Text = text,
				Font = new Font("Segoe UI", 15F),
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				AutoSize = true,
				Location = new Point(10, 10),
				Padding = new Padding(5)
			};
			return repeatLabel;
		}

		public Button CreateRemoveButton()
		{
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
				this.Parent.Controls.Remove(this);
			};

			return removeButton;
		}

		public void AddTaskPanel(string text)
		{
			TaskPanel newPanel = new TaskPanel(text)
			{
				Margin = new Padding(20, 5, 0, 0)
			};
			this.Controls.Add(newPanel);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.DoDragDrop(this, DragDropEffects.Move);
			}
		}

		private void OnDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(RepeatPanel)) || e.Data.GetDataPresent(typeof(TaskPanel)))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void OnDragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TaskPanel)))
			{
				TaskPanel droppedPanel = (TaskPanel)e.Data.GetData(typeof(TaskPanel));

				// Remove the dragged panel from its current parent
				droppedPanel.Parent.Controls.Remove(droppedPanel);

				// Create a new panel to represent the dropped panel in RepeatPanel
				this.AddTaskPanel(droppedPanel.Controls[0].Text);
			}
			else if (e.Data.GetDataPresent(typeof(RepeatPanel)))
			{
				RepeatPanel draggedRepeatPanel = (RepeatPanel)e.Data.GetData(typeof(RepeatPanel));

				if (draggedRepeatPanel == this) // Prevent it from removing itself
				{
					return;
				}

				draggedRepeatPanel.Parent.Controls.Remove(draggedRepeatPanel);
				
				var newRepeatPanel = new RepeatPanel(draggedRepeatPanel._repeatLabel.Text)
				{
					Margin = new Padding(20, 5, 0, 0)
				};

				while (draggedRepeatPanel.Controls.Count > 0)
				{
					Control child = draggedRepeatPanel.Controls[0];
					draggedRepeatPanel.Controls.Remove(child);
					if (child is Panel || child is RepeatPanel)
						newRepeatPanel.Controls.Add(child);
				}

				this.Controls.Add(newRepeatPanel);
			}
		}
	}
}