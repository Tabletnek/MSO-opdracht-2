namespace MSO_opdracht_3
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			button1 = new Button();
			textBox = new TextBox();
			loadProgramBox = new ComboBox();
			toolTip = new ToolTip(components);
			runButton = new Button();
			calculateButton = new Button();
			turnButton = new Button();
			dropLabel = new TextBox();
			moveButton = new Button();
			repeatButton = new Button();
			flowLayoutPanel1 = new FlowLayoutPanel();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(203, 78);
			button1.Name = "button1";
			button1.Size = new Size(367, 34);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox
			// 
			textBox.BorderStyle = BorderStyle.FixedSingle;
			textBox.Location = new Point(194, 145);
			textBox.Multiline = true;
			textBox.Name = "textBox";
			textBox.ReadOnly = true;
			textBox.ScrollBars = ScrollBars.Vertical;
			textBox.Size = new Size(568, 605);
			textBox.TabIndex = 1;
			// 
			// loadProgramBox
			// 
			loadProgramBox.AllowDrop = true;
			loadProgramBox.BackColor = Color.White;
			loadProgramBox.Font = new Font("Segoe UI", 12F);
			loadProgramBox.ForeColor = Color.Blue;
			loadProgramBox.FormattingEnabled = true;
			loadProgramBox.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "from file..." });
			loadProgramBox.Location = new Point(12, 12);
			loadProgramBox.Name = "loadProgramBox";
			loadProgramBox.Size = new Size(182, 40);
			loadProgramBox.TabIndex = 2;
			loadProgramBox.Text = "Load program";
			toolTip.SetToolTip(loadProgramBox, "Select a program to load or import from file.");
			loadProgramBox.SelectedIndexChanged += loadProgramBox_SelectedIndexChanged;
			// 
			// runButton
			// 
			runButton.Location = new Point(12, 248);
			runButton.Name = "runButton";
			runButton.Size = new Size(171, 62);
			runButton.TabIndex = 3;
			runButton.Text = "Run";
			runButton.UseVisualStyleBackColor = true;
			runButton.Click += runButton_Click;
			// 
			// calculateButton
			// 
			calculateButton.Location = new Point(12, 329);
			calculateButton.Name = "calculateButton";
			calculateButton.Size = new Size(171, 62);
			calculateButton.TabIndex = 4;
			calculateButton.Text = "Calculate";
			calculateButton.UseVisualStyleBackColor = true;
			calculateButton.Click += calculateButton_Click;
			// 
			// turnButton
			// 
			turnButton.BackColor = Color.Blue;
			turnButton.BackgroundImageLayout = ImageLayout.Zoom;
			turnButton.Font = new Font("Segoe UI", 30F);
			turnButton.ForeColor = Color.White;
			turnButton.Location = new Point(96, 781);
			turnButton.Name = "turnButton";
			turnButton.Size = new Size(256, 140);
			turnButton.TabIndex = 5;
			turnButton.Text = "Turn";
			turnButton.UseVisualStyleBackColor = false;
			turnButton.MouseDown += turnButton_MouseDown;
			// 
			// dropLabel
			// 
			dropLabel.AllowDrop = true;
			dropLabel.BackColor = SystemColors.ActiveCaption;
			dropLabel.Enabled = false;
			dropLabel.Font = new Font("Segoe UI", 20F);
			dropLabel.Location = new Point(784, 195);
			dropLabel.Multiline = true;
			dropLabel.Name = "dropLabel";
			dropLabel.ReadOnly = true;
			dropLabel.ScrollBars = ScrollBars.Vertical;
			dropLabel.Size = new Size(553, 555);
			dropLabel.TabIndex = 6;
			dropLabel.DragDrop += dropLabel_DragDrop;
			dropLabel.DragEnter += dropLabel_DragEnter;
			// 
			// moveButton
			// 
			moveButton.BackColor = Color.Blue;
			moveButton.BackgroundImageLayout = ImageLayout.Zoom;
			moveButton.Font = new Font("Segoe UI", 30F);
			moveButton.ForeColor = Color.White;
			moveButton.Location = new Point(400, 781);
			moveButton.Name = "moveButton";
			moveButton.Size = new Size(256, 140);
			moveButton.TabIndex = 7;
			moveButton.Text = "Move";
			moveButton.UseVisualStyleBackColor = false;
			moveButton.MouseDown += moveButton_MouseDown;
			// 
			// repeatButton
			// 
			repeatButton.BackColor = Color.Blue;
			repeatButton.BackgroundImageLayout = ImageLayout.Zoom;
			repeatButton.Font = new Font("Segoe UI", 30F);
			repeatButton.ForeColor = Color.White;
			repeatButton.Location = new Point(697, 781);
			repeatButton.Name = "repeatButton";
			repeatButton.Size = new Size(256, 140);
			repeatButton.TabIndex = 8;
			repeatButton.Text = "Repeat";
			repeatButton.UseVisualStyleBackColor = false;
			repeatButton.MouseDown += repeatButton_MouseDown;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AllowDrop = true;
			flowLayoutPanel1.AutoScroll = true;
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.Location = new Point(806, 12);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(428, 763);
			flowLayoutPanel1.TabIndex = 9;
			flowLayoutPanel1.WrapContents = false;
			flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;
			flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1600, 1000);
			Controls.Add(flowLayoutPanel1);
			Controls.Add(repeatButton);
			Controls.Add(moveButton);
			Controls.Add(dropLabel);
			Controls.Add(turnButton);
			Controls.Add(calculateButton);
			Controls.Add(runButton);
			Controls.Add(loadProgramBox);
			Controls.Add(textBox);
			Controls.Add(button1);
			Name = "MainForm";
			Text = "Programming learning";
			Load += MainForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private TextBox textBox;
		private ComboBox loadProgramBox;
		private ToolTip toolTip;
		private Button runButton;
		private Button calculateButton;
		private Button turnButton;
		private TextBox dropLabel;
		private Button moveButton;
		private Button repeatButton;
		private FlowLayoutPanel flowLayoutPanel1;
	}
}