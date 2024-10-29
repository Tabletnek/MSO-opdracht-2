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
                    chosenProgram = basicProgram;
                    break;
                case "Advanced":
                    chosenProgram = advancedProgram;
                    break;
                case "Expert":
                    chosenProgram = expertProgram;
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
                chosenProgram = translator.TranslateFile(filePath);
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
            if (chosenProgram != null)
            {
                textBox.Text = chosenProgram.Run();
            }
            else
            {
                MessageBox.Show("Please load a program first.");
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

        //Load the current program made using the builder blocks.
        private void runBlock_Click(object sender, EventArgs e)
        {
            if (int.TryParse(sizeBox.Text, out int programSize))
            {
                chosenProgram = builderTranslator.TranslateBuilder(programBuilder, programSize);
                MessageBox.Show("Program built successfully from panels.");

            }
            else
            {
                MessageBox.Show("Please enter a valid program size.");
                return;
            }

        }

        //Calculate the amount of commands, repeats and nesting of the current loaded program
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

        //Make the buttons draggable
        private void draggable_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.DoDragDrop(b.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
