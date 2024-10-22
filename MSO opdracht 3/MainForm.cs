using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
		private TaskProgram expertProgram = new TaskProgram(100);

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

		private void dropLabel_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		//Observer patroon gebruiken om deze dropLabel te bekijken en aan de hand daarvan echte tasks toe te voegen.
		private void dropLabel_DragDrop(object sender, DragEventArgs e)
		{
			string text = e.Data.GetData(DataFormats.Text).ToString();
			string input = null;

			//https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.interaction.inputbox?view=net-8.0
			switch (text)
			{
				case "Move":
					input = Interaction.InputBox("How many steps?\nType any number, e.g 5", "Move");
					if (input != null)
						if (int.TryParse(input, out int number))
							dropLabel.Text += $"{text} {number} \r\n";
					break;
				case "Turn":
					input = Interaction.InputBox("In what direction?\nType 'left' or 'right'", "Turn");
					if (input != null)
						if (input == "right" ||  input == "left")
							dropLabel.Text += $"{text} {input} \r\n";
					break;
				case "Repeat":
					input = Interaction.InputBox("How many times?\nType any number, e.g 5", "Repeat");
					if (input != null)
						if (int.TryParse(input, out int number))
							dropLabel.Text += $"{text} {number} \r\n";
					break;
			}
		}
	}
}
