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
			textBox = new Label();
			loadProgramBox = new ComboBox();
			toolTip = new ToolTip(components);
			runButton = new Button();
			calculateButton = new Button();
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
			textBox.Location = new Point(203, 145);
			textBox.Name = "textBox";
			textBox.Size = new Size(585, 246);
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
			// Programming learning
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1600, 1000);
			Controls.Add(calculateButton);
			Controls.Add(runButton);
			Controls.Add(loadProgramBox);
			Controls.Add(textBox);
			Controls.Add(button1);
			Name = "Programming learning";
			Text = "Programming learning";
			Load += MainForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private Label textBox;
		private ComboBox loadProgramBox;
		private ToolTip toolTip;
		private Button runButton;
		private Button calculateButton;
	}
}