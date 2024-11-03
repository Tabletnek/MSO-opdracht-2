namespace MSO_Opdracht_3
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
            textBox.Location = new Point(192, 10);
            textBox.Margin = new Padding(2, 2, 2, 2);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Size = new Size(455, 591);
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
            loadProgramBox.Location = new Point(10, 10);
            loadProgramBox.Margin = new Padding(2, 2, 2, 2);
            loadProgramBox.Name = "loadProgramBox";
            loadProgramBox.Size = new Size(146, 36);
            loadProgramBox.TabIndex = 2;
            loadProgramBox.Text = "Load program";
            toolTip.SetToolTip(loadProgramBox, "Select a program to load or import from file.");
            loadProgramBox.SelectedIndexChanged += loadProgramBox_SelectedIndexChanged;
            // 
            // loadExerciseBox
            // 
            loadExerciseBox.AllowDrop = true;
            loadExerciseBox.BackColor = Color.White;
            loadExerciseBox.Font = new Font("Segoe UI", 12F);
            loadExerciseBox.ForeColor = Color.Blue;
            loadExerciseBox.FormattingEnabled = true;
            loadExerciseBox.Items.AddRange(new object[] { "None", "Basic", "Advanced", "Expert", "from file..." });
            loadExerciseBox.Location = new Point(10, 65);
            loadExerciseBox.Margin = new Padding(2);
            loadExerciseBox.Name = "loadExerciseBox";
            loadExerciseBox.Size = new Size(146, 36);
            loadExerciseBox.TabIndex = 13;
            loadExerciseBox.Text = "Load exercise";
            toolTip.SetToolTip(loadExerciseBox, "Select a exercise to load or import from file.");
            loadExerciseBox.SelectedIndexChanged += loadExerciseBox_SelectedIndexChanged;
            // 
            // runButton
            // 
            runButton.Location = new Point(10, 198);
            runButton.Margin = new Padding(2, 2, 2, 2);
            runButton.Name = "runButton";
            runButton.Size = new Size(137, 50);
            runButton.TabIndex = 3;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(10, 263);
            calculateButton.Margin = new Padding(2, 2, 2, 2);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(137, 50);
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
            turnButton.Location = new Point(192, 625);
            turnButton.Margin = new Padding(2, 2, 2, 2);
            turnButton.Name = "turnButton";
            turnButton.Size = new Size(155, 81);
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
            moveButton.Location = new Point(375, 625);
            moveButton.Margin = new Padding(2, 2, 2, 2);
            moveButton.Name = "moveButton";
            moveButton.Size = new Size(161, 81);
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
            repeatButton.Location = new Point(560, 625);
            repeatButton.Margin = new Padding(2, 2, 2, 2);
            repeatButton.Name = "repeatButton";
            repeatButton.Size = new Size(191, 81);
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
            programBuilder.Location = new Point(709, 10);
            programBuilder.Margin = new Padding(2, 2, 2, 2);
            programBuilder.Name = "programBuilder";
            programBuilder.Size = new Size(480, 591);
            programBuilder.TabIndex = 9;
            programBuilder.WrapContents = false;
            // 
            // sizeBox
            // 
            sizeBox.Location = new Point(14, 328);
            sizeBox.Margin = new Padding(2, 2, 2, 2);
            sizeBox.Name = "sizeBox";
            sizeBox.Size = new Size(134, 27);
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
            repeatUntilButton.Location = new Point(783, 625);
            repeatUntilButton.Margin = new Padding(2, 2, 2, 2);
            repeatUntilButton.Name = "repeatUntilButton";
            repeatUntilButton.Size = new Size(282, 81);
            repeatUntilButton.TabIndex = 12;
            repeatUntilButton.Text = "RepeatUntil";
            repeatUntilButton.UseVisualStyleBackColor = false;
            repeatUntilButton.MouseDown += draggable_MouseDown;
            // 
            // boardDisplay
            // 
            boardDisplay.Location = new Point(1200, 10);
            boardDisplay.Margin = new Padding(2, 2, 2, 2);
            boardDisplay.Name = "boardDisplay";
            boardDisplay.Size = new Size(640, 640);
            boardDisplay.TabIndex = 13;
            boardDisplay.TaskProgram = null;
            // 
            // clearBlocksButton
            // 
            clearBlocksButton.BackColor = Color.Red;
            clearBlocksButton.ForeColor = Color.White;
            clearBlocksButton.Location = new Point(10, 687);
            clearBlocksButton.Margin = new Padding(2, 2, 2, 2);
            clearBlocksButton.Name = "clearBlocksButton";
            clearBlocksButton.Size = new Size(137, 50);
            clearBlocksButton.TabIndex = 14;
            clearBlocksButton.Text = "Clear Blocks";
            clearBlocksButton.UseVisualStyleBackColor = false;
            clearBlocksButton.Click += clearBlocksButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1539, 746);
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
            Margin = new Padding(2, 2, 2, 2);
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