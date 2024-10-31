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
			textBox = new TextBox();
			loadProgramBox = new ComboBox();
            loadExerciseBox = new ComboBox();
            toolTip = new ToolTip(components);
			runButton = new Button();
			calculateButton = new Button();
			turnButton = new Button();
			moveButton = new Button();
			repeatButton = new Button();
			programBuilder = new ProgramBuilder();
			sizeBox = new TextBox();
			repeatUntilButton = new Button();
			boardDisplay = new BoardDisplay();
			clearBlocksButton = new Button();
			SuspendLayout();
			// 
			// textBox
			// 
			textBox.BorderStyle = BorderStyle.FixedSingle;
			textBox.Location = new Point(240, 12);
			textBox.Multiline = true;
			textBox.Name = "textBox";
			textBox.ReadOnly = true;
			textBox.ScrollBars = ScrollBars.Vertical;
			textBox.Size = new Size(568, 738);
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
            // loadExercisesBox
            // 
            loadExerciseBox.AllowDrop = true;
            loadExerciseBox.BackColor = Color.White;
            loadExerciseBox.Font = new Font("Segoe UI", 12F);
            loadExerciseBox.ForeColor = Color.Blue;
            loadExerciseBox.FormattingEnabled = true;
            loadExerciseBox.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "from file..." });
            loadExerciseBox.Location = new Point(10, 386);
            loadExerciseBox.Margin = new Padding(2);
            loadExerciseBox.Name = "loadExercisesBox";
            loadExerciseBox.Size = new Size(146, 36);
            loadExerciseBox.TabIndex = 13;
            loadExerciseBox.Text = "Load exercise";
            toolTip.SetToolTip(loadExerciseBox, "Select a exercise to load or import from file.");
            loadExerciseBox.SelectedIndexChanged += loadExerciseBox_SelectedIndexChanged;
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
			turnButton.Location = new Point(240, 781);
			turnButton.Name = "turnButton";
			turnButton.Size = new Size(194, 101);
			turnButton.TabIndex = 5;
			turnButton.Text = "Turn";
			turnButton.UseVisualStyleBackColor = false;
			turnButton.MouseDown += draggable_MouseDown;
			// 
			// moveButton
			// 
			moveButton.BackColor = Color.Blue;
			moveButton.BackgroundImageLayout = ImageLayout.Zoom;
			moveButton.Font = new Font("Segoe UI", 30F);
			moveButton.ForeColor = Color.White;
			moveButton.Location = new Point(469, 781);
			moveButton.Name = "moveButton";
			moveButton.Size = new Size(201, 101);
			moveButton.TabIndex = 7;
			moveButton.Text = "Move";
			moveButton.UseVisualStyleBackColor = false;
			moveButton.MouseDown += draggable_MouseDown;
			// 
			// repeatButton
			// 
			repeatButton.BackColor = Color.Blue;
			repeatButton.BackgroundImageLayout = ImageLayout.Zoom;
			repeatButton.Font = new Font("Segoe UI", 30F);
			repeatButton.ForeColor = Color.White;
			repeatButton.Location = new Point(700, 781);
			repeatButton.Name = "repeatButton";
			repeatButton.Size = new Size(239, 101);
			repeatButton.TabIndex = 8;
			repeatButton.Text = "Repeat";
			repeatButton.UseVisualStyleBackColor = false;
			repeatButton.MouseDown += draggable_MouseDown;
			// 
			// programBuilder
			// 
			programBuilder.AllowDrop = true;
			programBuilder.AutoScroll = true;
			programBuilder.BorderStyle = BorderStyle.FixedSingle;
			programBuilder.FlowDirection = FlowDirection.TopDown;
			programBuilder.Location = new Point(886, 12);
			programBuilder.Name = "programBuilder";
			programBuilder.Size = new Size(600, 738);
			programBuilder.TabIndex = 9;
			programBuilder.WrapContents = false;
			// 
			// sizeBox
			// 
			sizeBox.Location = new Point(17, 410);
			sizeBox.Name = "sizeBox";
			sizeBox.Size = new Size(166, 31);
			sizeBox.TabIndex = 11;
			sizeBox.Text = "Put in Size";
			sizeBox.TextChanged += sizeBox_TextChanged;
			sizeBox.KeyPress += sizeBox_KeyPress;
			// 
			// repeatUntilButton
			// 
			repeatUntilButton.BackColor = Color.Blue;
			repeatUntilButton.BackgroundImageLayout = ImageLayout.Zoom;
			repeatUntilButton.Font = new Font("Segoe UI", 30F);
			repeatUntilButton.ForeColor = Color.White;
			repeatUntilButton.Location = new Point(979, 781);
			repeatUntilButton.Name = "repeatUntilButton";
			repeatUntilButton.Size = new Size(353, 101);
			repeatUntilButton.TabIndex = 12;
			repeatUntilButton.Text = "RepeatUntil";
			repeatUntilButton.UseVisualStyleBackColor = false;
			repeatUntilButton.MouseDown += draggable_MouseDown;
			// 
			// boardDisplay
			// 
			boardDisplay.Location = new Point(1500, 12);
			boardDisplay.Name = "boardDisplay";
			boardDisplay.Size = new Size(801, 801);
			boardDisplay.TabIndex = 13;
			boardDisplay.TaskProgram = null;
			// 
			// clearBlocksButton
			// 
			clearBlocksButton.BackColor = Color.Red;
			clearBlocksButton.ForeColor = Color.White;
			clearBlocksButton.Location = new Point(12, 859);
			clearBlocksButton.Name = "clearBlocksButton";
			clearBlocksButton.Size = new Size(171, 62);
			clearBlocksButton.TabIndex = 14;
			clearBlocksButton.Text = "Clear Blocks";
			clearBlocksButton.UseVisualStyleBackColor = false;
			clearBlocksButton.Click += clearBlocksButton_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1972, 933);
			Controls.Add(clearBlocksButton);
			Controls.Add(repeatUntilButton);
			Controls.Add(sizeBox);
			Controls.Add(programBuilder);
			Controls.Add(repeatButton);
			Controls.Add(moveButton);
			Controls.Add(turnButton);
			Controls.Add(calculateButton);
			Controls.Add(runButton);
			Controls.Add(loadProgramBox);
            Controls.Add(loadExerciseBox);
            Controls.Add(textBox);
			Controls.Add(boardDisplay);
			Name = "MainForm";
			Text = "Programming learning";
			WindowState = FormWindowState.Maximized;
			ResumeLayout(false);
			PerformLayout();
		}

        #endregion
        private TextBox textBox;
		private ComboBox loadProgramBox;
        private ComboBox loadExerciseBox;
        private ToolTip toolTip;
		private Button runButton;
		private Button calculateButton;
		private Button turnButton;
		private Button moveButton;
		private Button repeatButton;
		private ProgramBuilder programBuilder;
		private TextBox sizeBox;
		private Button repeatUntilButton;
		private BoardDisplay boardDisplay;
		private Button clearBlocksButton;
	}
}