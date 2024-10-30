﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_3
{
	public class TaskPanel: Panel

	{
		public TaskPanel(string text)
		{
			this.Size = new Size(400, 80);
			this.BackColor = Color.MediumPurple;
			this.BorderStyle = BorderStyle.FixedSingle;

			this.MouseDown += OnMouseDown;

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
				this.Parent.Controls.Remove(this);
			};

			this.Controls.Add(taskLabel);
			this.Controls.Add(removeButton);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.DoDragDrop((Panel)sender, DragDropEffects.Move);
			}
		}
	}
}
