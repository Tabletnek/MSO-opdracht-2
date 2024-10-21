using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSO_opdracht_3
{
	public partial class MainForm : Form
	{
		TaskProgram chosenProgram = null;
		private Translator translator;
		private Calculator calculator;
		private TaskProgram basicProgram = new TaskProgram(10);
		private TaskProgram advancedProgram = new TaskProgram(10);
		private TaskProgram expertProgram = new TaskProgram(10);

		public MainForm()
		{
			InitializeComponent();
			translator = new Translator();
			calculator = new Calculator();

			// Create the Example Programs
			basicProgram.AddTask(new Move(10));
			basicProgram.AddTask(new Turn("left"));

			advancedProgram.AddTask(new Repeat(4, basicProgram.tasks));

			expertProgram.AddTask(new Repeat(3, advancedProgram.tasks));
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox.Text = "Dit is een fantastische test";
		}

		private void loadProgramBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (loadProgramBox.SelectedItem)
			{
				case "Basic":
					chosenProgram = basicProgram;
					break;
				case "Advanced":
					chosenProgram = advancedProgram;
					break;
				case "Expert":
					chosenProgram = expertProgram;
					break;
				case "from file...":
					{
						// I used https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog.initialdirectory?view=windowsdesktop-8.0
						// and https://stackoverflow.com/questions/21769921/does-openfiledialog-initialdirectory-not-accept-relative-path
						// Logic to open file dialog and load a program
						string initialDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\");
						OpenFileDialog openFileDialog = new OpenFileDialog
						{
							Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
							Title = "Select a Program File",
							InitialDirectory = Path.GetFullPath(initialDirectory)
						};

						if (openFileDialog.ShowDialog() == DialogResult.OK)
						{
							string filePath = openFileDialog.FileName;
							string fileName = Path.GetFileName(filePath);

							loadProgramBox.Text = fileName;
							chosenProgram = translator.TranslateFile(filePath);
							MessageBox.Show("Task program imported successfully.");

						}
					}
					break;
			}
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			if (chosenProgram != null)
			{
				textBox.Text = chosenProgram.Run();
			}
			else
			{
				MessageBox.Show("Please load a program first.");
			}
		}

		private void calculateButton_Click(object sender, EventArgs e)
		{
			if (chosenProgram != null)
			{
				int commandCount = calculator.numOfCommands(chosenProgram);
				int repeatCount = calculator.numOfRepeats(chosenProgram);
				int maxNestLevel = calculator.maxNestLvl(chosenProgram);

				textBox.Text = $"The amount of commands of this program is: {commandCount}\n" +
							   $"The amount of repeats of this program is: {repeatCount}\n" +
							   $"The max level of nesting of this program is: {maxNestLevel}";
			}
			else
			{
				MessageBox.Show("Please load a program first.");
			}
		}
	}
}
