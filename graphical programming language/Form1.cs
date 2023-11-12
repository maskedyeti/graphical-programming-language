using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    public partial class Form1 : Form
    {    
        public Form1()
        {
            InitializeComponent();
            commands.DrawingManager(); //initialises pen object

        }

        public Boolean fill = false;
        public List<int> penCoordinates = new List<int> { 10, 10 };

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Executes a list of commands for drawing on a panel
        /// </summary>
        /// <param name="commandLine">List of commands to execute</param>
        public void executeLine(List<string> commandLine)
        {
            List<string> commandList = commandLine;

            if (commandList[0] == "error")
            {
                MessageBox.Show((commandList[1]));

            }
            else
            {
                using (Graphics g = panel1.CreateGraphics())

                {

                    if ((commandList[0] == "moveto"))

                    {

                        commands.moveTo(penCoordinates, int.Parse(commandList[1]), int.Parse(commandList[2]));

                    }

                    else if ((commandList[0]) == "rectangle")

                    {

                        commands.rectangle(g, penCoordinates[0], penCoordinates[1], int.Parse(commandList[1]), int.Parse(commandList[2]), fill);

                    }

                    else if ((commandList[0]) == "clear")

                    {

                        panel1.Invalidate();

                    }

                    else if ((commandList[0]) == "circle")

                    {

                        commands.circle(g, penCoordinates[0], penCoordinates[1], int.Parse(commandList[1]), fill);

                    }

                    else if (commandList[0] == "triangle")

                    {

                        commands.triangle(g, penCoordinates[0], penCoordinates[1],

                                                            int.Parse(commandList[1]), int.Parse(commandList[2]), fill);

                    }

                    else if ((commandList[0]) == "drawto")

                    {

                        commands.drawto(g, penCoordinates, int.Parse(commandList[1]), int.Parse(commandList[2]));

                    }

                    else if ((commandList[0]) == "pen")

                    {

                        commands.penColour(Color.FromName(commandList[1]));

                    }

                    else if ((commandList[0] == "reset"))

                    {

                        panel1.Invalidate();

                        commands.moveTo(penCoordinates, 10, 10);

                    }

                    else if (((commandList[0]) == "fill"))

                    {



                        if (commandList[1] == "on")

                        {

                            fill = true;



                        }

                        else if (commandList[1] == "off")

                        {

                            fill = false;

                        }

                    }
                
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event for the second text box
        /// Checks for the Enter key and processes the entered command
        /// </summary>
        /// <param name="sender">the event</param>
        /// <param name="e">A KeyEventArgs that contains event data</param>
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                List<string> commandList = Parser.processSingleLine(textBox2.Text); //checks for valid commands and stores for execution
                executeLine(commandList);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void paintBrushPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event for the first button
        /// Processes multiple lines of commands from textBox1
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> multiLine = Parser.multiLineProcess(textBox1);

            if (multiLine[0] == "error")
            {
                
            }
            else
            {
                for (int i = 0; i < multiLine.Count; i++)
                {

                    List<string> commandList = multiLine[i].Split(' ').ToList();

                    executeLine(commandList);
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the second button.
        /// Processes multiple commands from textBox1, syntax checks them and displays any errors as labels on panel1
        /// </summary>
        /// <param name="sender">The event source</param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> multiLine = Parser.multiLineProcess(textBox1);

            if (multiLine[0] == "error")
            {
                int y = 10;

                for (int i = 0; i < multiLine.Count; i++)
                {
                    Label label = new Label();
                    label.Width = 500;

                    label.AutoSize = true;
                    label.MaximumSize = new Size(panel1.Width - 20, 0);

                    label.Text = multiLine[i];
                    label.Location = new Point(10, y);
                    panel1.Controls.Add(label);

                    y += label.Height + 2;
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the third button
        /// Uses an OpenFileDialog to allow the selection of files through file explorer
        /// Reads the contents of the selected file and sets the text box's text to the file contents
        /// Displays a success message if the file is loaded successfully, otherwise, shows an error message
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">contains the event data.</param>
        public void button3_Click(object sender, EventArgs e)
        public void button3_Click(object sender, EventArgs e)//uses openfiledialog to allow selection of files thrpugh file explorer
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*"; // sets file filters
            openFileDialog1.Title = "Open Text File"; 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    string fileContents = File.ReadAllText(filePath);

                    // set the text box's text to the contents of the file
                    textBox1.Text = fileContents;

                    MessageBox.Show("File loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the fourth button
        /// Uses a SaveFileDialog to specify the file path and saves the contents of the text box to the selected file
        /// Displays a success message if the file is saved successfully; otherwise, shows an error message
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// <param name="e">contains the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*"; // sets file filters
            saveFileDialog1.Title = "Save Text File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;

                // Get the text from the text box
                string contentToSave = textBox1.Text;

                try
                {
                    File.WriteAllText(savePath, contentToSave);
                    MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
