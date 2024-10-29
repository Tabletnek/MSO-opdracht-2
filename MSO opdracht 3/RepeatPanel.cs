﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSO_opdracht_3
{
	public class RepeatPanel : FlowLayoutPanel
	{
		private Label repeatLabel;

		public RepeatPanel(string text)
		{
			this.MinimumSize = new Size(400, 80);
			this.BackColor = Color.Purple;
			this.BorderStyle = BorderStyle.FixedSingle;
			this.AutoSize = true;

			repeatLabel = new Label
			{
				Text = text,
				Font = new Font("Segoe UI", 15F),
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				AutoSize = true,
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
				this.Parent.Controls.Remove(this);
			};

			this.Controls.Add(repeatLabel);
			this.Controls.Add(removeButton);
			this.MouseDown += OnMouseDown;

			this.AllowDrop = true;
			this.DragEnter += OnDragEnter;
			this.DragDrop += OnDragDrop;    
		}

		public void AddTaskPanel(string text)
		{
			var taskPanel = new Panel
			{
				Size = new Size(400, 80),
				BackColor = Color.MediumPurple,
				Margin = new Padding(20, 5, 0, 0)
			};

			Label taskLabel = new Label
			{
				Text = text,
				Font = new Font("Segoe UI", 15F),
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				AutoSize = true,
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
				taskPanel.Parent.Controls.Remove(taskPanel);
			};

			taskPanel.Controls.Add(taskLabel);
			taskPanel.Controls.Add(removeButton);

			this.Controls.Add(taskPanel);
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
			if (e.Data.GetDataPresent(typeof(RepeatPanel)) || e.Data.GetDataPresent(typeof(Panel)))
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
			if (e.Data.GetDataPresent(typeof(Panel)))
			{
				Panel draggedPanel = (Panel)e.Data.GetData(typeof(Panel));
				// Remove the dragged panel from its current parent
				draggedPanel.Parent.Controls.Remove(draggedPanel);

				// Create a new panel to represent the dropped panel in RepeatPanel
				this.AddTaskPanel(draggedPanel.Controls[0].Text);
			}
			else if (e.Data.GetDataPresent(typeof(RepeatPanel)))
			{
				RepeatPanel draggedRepeatPanel = (RepeatPanel)e.Data.GetData(typeof(RepeatPanel));

				if (draggedRepeatPanel == this) // Prevent it from removing itself
				{
					return;
				}

				draggedRepeatPanel.Parent.Controls.Remove(draggedRepeatPanel);
				
				var newRepeatPanel = new RepeatPanel(draggedRepeatPanel.repeatLabel.Text)
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