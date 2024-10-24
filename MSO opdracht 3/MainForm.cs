using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MSO_opdracht_3
{
	public partial class MainForm : Form
	{
		TaskProgram chosenProgram = null;
		private Translator translator;
		private Calculator calculator;
		private TaskProgram basicProgram = new TaskProgram(10);
		private TaskProgram advancedProgram = new TaskProgram(10);
		private TaskProgram expertProgram = new TaskProgram(1000);

		public MainForm()
		{
			InitializeComponent();

			translator = new Translator();
			calculator = new Calculator();

			// Create the Example Programs
			basicProgram.AddTask(new Move(10));
			basicProgram.AddTask(new Move(2));

			advancedProgram.AddTask(new Repeat(4, basicProgram.tasks));

			//expertProgram.AddTask(new Move(1));
			//expertProgram.AddTask(new Turn("left"));
			//expertProgram.AddTask(new Move(1));
			//expertProgram.AddTask(new Turn("right"));
			expertProgram.AddTask(new RepeatWall(basicProgram.tasks));
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
						OpenFileDialog openFileDialog = new OpenFileDialog
						{
							Filter = "Text Files (*.txt)|*.txt",
							Title = "Select a Program File",
							InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"))
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

				textBox.Text = $"The amount of commands of this program is: {commandCount}\r\n" +
							   $"The amount of repeats of this program is: {repeatCount}\r\n" +
							   $"The max level of nesting of this program is: {maxNestLevel}";
			}
			else
			{
				MessageBox.Show("Please load a program first.");
			}
		}

		private void turnButton_MouseDown(object sender, MouseEventArgs e)
		{
			//https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8
			turnButton.DoDragDrop(turnButton.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private void moveButton_MouseDown(object sender, MouseEventArgs e)
		{
			//https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8
			moveButton.DoDragDrop(moveButton.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}
		private void repeatButton_MouseDown(object sender, MouseEventArgs e)
		{
			//https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8
			repeatButton.DoDragDrop(repeatButton.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}
	}
}
