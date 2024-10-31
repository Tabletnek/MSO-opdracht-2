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
        TaskProgram chosenProgram;
        IGrid chosenExercise = null; 
        private FileTranslator translator;
        private PathTranslator pathTranslator;
        private BuilderTranslator builderTranslator;
        private Calculator calculator;
        private TaskProgram basicProgram = new TaskProgram(10);
        private TaskProgram advancedProgram = new TaskProgram(10);
        private TaskProgram expertProgram = new TaskProgram(1000);

        private IGrid basicExercise = new PathFindingGrid(10);
        private IGrid advancedExercise = new PathFindingGrid(10);
        private IGrid expertExercise = new PathFindingGrid(10);

        public MainForm()
        {
            InitializeComponent();

            translator = new FileTranslator();
            pathTranslator = new PathTranslator();
            builderTranslator = new BuilderTranslator();
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

		//Load a program using one of the examples or one out of a textfile
		private void loadProgramBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (loadProgramBox.SelectedItem)
			{
				case "Basic":
					programBuilder.LoadProgram(basicProgram);
					LoadProgram(basicProgram);
					break;
				case "Advanced":
					programBuilder.LoadProgram(advancedProgram);
					LoadProgram(advancedProgram);
					break;
				case "Expert":
					programBuilder.LoadProgram(expertProgram);
					LoadProgram(expertProgram);
					break;
				case "from file...":
					LoadProgramFromFile();
					break;
			}
		}

        private void loadExerciseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (loadExerciseBox.SelectedItem)
            {
                case "Basic":
                    chosenExercise = basicExercise;
                    break;
                case "Advanced":
                    chosenExercise = advancedExercise;
                    break;
                case "Expert":
                    chosenExercise = expertExercise;
                    break;
                case "from file...":
                    LoadExerciseFromFile();
                    break;
            }
        }

        //Show the file explorer to choose a text file to load
        // I used https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog.initialdirectory?view=windowsdesktop-8.0
        // and https://stackoverflow.com/questions/21769921/does-openfiledialog-initialdirectory-not-accept-relative-path
        private void LoadProgramFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a Program File",
                InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"Programs")),
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

				loadProgramBox.Text = fileName;
				TaskProgram newProgram = translator.TranslateFile(filePath);
				programBuilder.LoadProgram(newProgram);
				LoadProgram(newProgram);
				MessageBox.Show("Task program imported successfully.");
			}
		}

        private void LoadExerciseFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a Exercise File",
                InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"Exercises")),
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                loadExerciseBox.Text = fileName;
                chosenExercise = pathTranslator.TranslateFile(filePath);
                MessageBox.Show("Exercise imported successfully.");
            }
        }

		//Run the current loaded program (if one is loaded) and show the output in the text box
		private void runButton_Click(object sender, EventArgs e)
		{
			if (chosenProgram != null && int.TryParse(sizeBox.Text, out int programSize))
			{
				LoadProgram(builderTranslator.TranslateBuilder(programBuilder, programSize));
				textBox.Text = chosenProgram.Run();
				boardDisplay.TaskProgram = chosenProgram;
			}
			else
			{
				MessageBox.Show("Please set a size first");
			}
		}

        //Make sure only numbers can be entered
        //https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
        private void sizeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

		private void sizeBox_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(sizeBox.Text, out int programSize))
			{
					LoadProgram(builderTranslator.TranslateBuilder(programBuilder, programSize));
			}
		}

		//Calculate the amount of commands, repeats and nesting of the current loaded program
		private void calculateButton_Click(object sender, EventArgs e)
		{
			if (chosenProgram != null)
			{
				LoadProgram(builderTranslator.TranslateBuilder(programBuilder, chosenProgram.grid.size));
				int commandCount = calculator.numOfCommands(chosenProgram);
				int repeatCount = calculator.numOfRepeats(chosenProgram);
				int maxNestLevel = calculator.maxNestLvl(chosenProgram);

				textBox.Text = $"The amount of commands of this program is: {commandCount}\r\n" +
							   $"The amount of repeats of this program is: {repeatCount}\r\n" +
							   $"The max level of nesting of this program is: {maxNestLevel}";
			}
			else
			{
				MessageBox.Show("Please load a program first. You can do this by setting a size, or importing/creating one");
			}
		}

		public void LoadProgram(TaskProgram program)
		{
			chosenProgram = program;
			boardDisplay.TaskProgram = chosenProgram;
			sizeBox.Text = chosenProgram.grid.size.ToString();
		}

		//Make the buttons draggable
		private void draggable_MouseDown(object sender, MouseEventArgs e)
		{
			Button b = (Button)sender;
			b.DoDragDrop(b.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private void clearBlocksButton_Click(object sender, EventArgs e)
		{
			programBuilder.Controls.Clear();
			if (chosenProgram != null)
			{
				int programSize = chosenProgram.grid.size;
				LoadProgram(builderTranslator.TranslateBuilder(programBuilder, programSize));
				textBox.Text = "";
			}
		}
	}
}
