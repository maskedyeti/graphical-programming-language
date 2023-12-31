﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.Threading;
using System.Linq.Expressions;

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
        public List<int> penCoordinates1 = new List<int> { 10, 10 };
        public List<int> penCoordinates2 = new List<int> { 10, 10 };


        public OpenFileDialog OpenFileDialog { get; set; }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void executeLine(List<string> commandLine, List<int> penCoordinates)
        {
            List<string> commandList = commandLine;
            VariableFactory variableFactory = new VariableFactory();

            if (InvokeRequired)
            {
                Invoke(new Action(() => executeLine(commandLine, penCoordinates)));
                return;
            }

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

                        List<int> moveToParameters = twoIntCommandVariable(commandList);
                        commands.moveTo(penCoordinates, moveToParameters[0], moveToParameters[1]);

                    }

                    else if ((commandList[0]) == "rectangle")

                    {
                        List<int> rectangleParameters = twoIntCommandVariable(commandList);
                        commands.rectangle(g, penCoordinates[0], penCoordinates[1], rectangleParameters[0], rectangleParameters[1], fill);

                    }

                    else if ((commandList[0]) == "clear")

                    {

                        panel1.Invalidate();

                    }

                    else if ((commandList[0]) == "circle")

                    {

                        
                        commands.circle(g, penCoordinates[0], penCoordinates[1], oneIntCommandVariable(commandList), fill);

                    }

                    else if (commandList[0] == "triangle")

                    {

                        List<int> triangleleParameters = twoIntCommandVariable(commandList);
                        commands.triangle(g, penCoordinates[0], penCoordinates[1],

                                                            triangleleParameters[0], triangleleParameters[1], fill);

                    }

                    else if (commandList[0] == "drawrotatedrectangle")
                    {
                        List<int> rectangleParameters = threeIntCommandVariable(commandList);
                        commands.DrawRotatedRectangle(g, penCoordinates[0], penCoordinates[1], rectangleParameters[0], rectangleParameters[1], rectangleParameters[2]);
                    }

                    else if (commandList[0] == "drawrotatedtriangle")
                    {
                        List<int> triangleleParameters = threeIntCommandVariable(commandList);
                        commands.DrawRotatedTriangle(g, penCoordinates[0], penCoordinates[1],

                                                            triangleleParameters[0], triangleleParameters[1], triangleleParameters[2]);
                    }

                    else if (commandList[0] == "drawa") //maybe include
                    {
                        commands.DrawLetterA(g, penCoordinates[0], penCoordinates[1], 20);
                    }

                    else if ((commandList[0]) == "drawto")

                    {

                        List<int> drawToParameters = twoIntCommandVariable(commandList);
                        commands.drawto(g, penCoordinates, drawToParameters[0], drawToParameters[1]);

                    }

                    else if ((commandList[0]) == "pen")

                    {

                        commands.penColour(Color.FromName(commandList[1]));

                    }

                    else if ((commandList[0] == "reset"))

                    {

                        panel1.Invalidate();

                        penCoordinates1[0] = 10;
                        penCoordinates1[1] = 10;

                        penCoordinates2[0] = 10;
                        penCoordinates2[1] = 10;

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
                    else if (commandList.Count() == 3 && commandList[1] == "=")
                    {
                        if (int.TryParse(commandList[2], out int value))
                        {

                           Variable a = variableFactory.CreateVariable(commandList[0], value);
                            Parser.variables[a.Name] = a.Value;
                            

                        }

                    }
                    else if (commandList.Count() == 5 && commandList[1] == "=" && Parser.operations.Contains(commandList[3]))
                    {

                        if (int.TryParse(commandList[2], out int operand1) && int.TryParse(commandList[4], out int operand2))
                        {

                            Variable a = variableFactory.MathsVariable(commandList[0], 0, operand1, operand2, commandList[3]);
                            Parser.variables[a.Name] = a.Value;

                        }
                        else if (Parser.variables.ContainsKey(commandList[2]) && int.TryParse(commandList[4], out int operand2a))
                        {
                            Variable a = variableFactory.MathsVariable(commandList[0], 0, Parser.variables[commandList[2]], operand2a, commandList[3]);
                            Parser.variables[a.Name] = a.Value;

                        }
                        else if (Parser.variables.ContainsKey(commandList[4]) && int.TryParse(commandList[2], out int operand1a))
                        {
                            Variable a = variableFactory.MathsVariable(commandList[0], 0, operand1a, Parser.variables[commandList[4]], commandList[3]);
                            Parser.variables[a.Name] = a.Value;
                        }
                        else if (Parser.variables.ContainsKey(commandList[4]) && Parser.variables.ContainsKey(commandList[2]))
                        {
                            Variable a = variableFactory.MathsVariable(commandList[0], 0, Parser.variables[commandList[2]], Parser.variables[commandList[4]], commandList[3]);
                            Parser.variables[a.Name] = a.Value;
                        }

                    }

                }
            }
        }

        private List<int> threeIntCommandVariable(List<string> commandList)
        {
            if (int.TryParse(commandList[1], out int numa1) && int.TryParse(commandList[2], out int numb1) && int.TryParse(commandList[3], out int numc1))
            {
                List<int> validatedCommands = new List<int> { numa1, numb1, numc1 };
                return validatedCommands;

            }
            else if (int.TryParse(commandList[1], out int numa11) && int.TryParse(commandList[2], out int numb11) && Parser.variables.ContainsKey(commandList[3]))
            {
                List<int> validatedCommands = new List<int> { numa11, numb11, Parser.variables[commandList[3]] };
                return validatedCommands;

            }
            else if (int.TryParse(commandList[1], out int numa2) && Parser.variables.ContainsKey(commandList[2]) && int.TryParse(commandList[2], out int numc2))
            {
                List<int> validatedCommands = new List<int> { numa2, Parser.variables[commandList[2]], numc2 };
                return validatedCommands;

            }
            else if (int.TryParse(commandList[1], out int numa3) && Parser.variables.ContainsKey(commandList[2]) && Parser.variables.ContainsKey(commandList[3]))
            {
                List<int> validatedCommands = new List<int> { numa3, Parser.variables[commandList[2]], Parser.variables[commandList[3]]};
                return validatedCommands;

            }
            else if (Parser.variables.ContainsKey(commandList[1]) && int.TryParse(commandList[1], out int numb2) && Parser.variables.ContainsKey(commandList[3]))
            {
                List<int> validatedCommands = new List<int> { Parser.variables[commandList[1]], numb2, Parser.variables[commandList[3]]};
                return validatedCommands;

            }
            else if (Parser.variables.ContainsKey(commandList[1]) && int.TryParse(commandList[1], out int numb4) && int.TryParse(commandList[2], out int numc4))
            {
                List<int> validatedCommands = new List<int> { Parser.variables[commandList[1]], numb4, numc4 };
                return validatedCommands;

            }
            else
            {
                List<int> validtaedCommands = new List<int> { Parser.variables[commandList[1]], Parser.variables[commandList[2]], Parser.variables[commandList[3]] };
                return validtaedCommands;
            }
        }

        private List<int> twoIntCommandVariable (List<string> commandList)
        {
            if (int.TryParse(commandList[1], out int numa1) && int.TryParse(commandList[2], out int numb1))
            {
                List<int> validatedCommands = new List<int> { numa1, numb1 };
                return validatedCommands;

            }
            else if (int.TryParse(commandList[1], out int numa2) && Parser.variables.ContainsKey(commandList[2]))
            {
                List<int> validatedCommands = new List<int> { numa2, Parser.variables[commandList[2]] };
                return validatedCommands;

            }
            else if (Parser.variables.ContainsKey(commandList[1]) && int.TryParse(commandList[1], out int numb2))
            {
                List<int> validatedCommands = new List<int> { Parser.variables[commandList[1]], numb2 };
                return validatedCommands;

            }
            else
            {
                List<int> validtaedCommands = new List<int> { Parser.variables[commandList[1]], Parser.variables[commandList[2]] };
                return validtaedCommands;
            }
        }

        private int oneIntCommandVariable (List<string> commandList)
        {
            if (int.TryParse(commandList[1], out int num1a))
            {
                return num1a;
            }
            else
            {
                return Parser.variables[commandList[1]];
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                List<string> commandList = Parser.processSingleLine(textBox2.Text); //checks for valid commands and stores for execution
                executeLine(commandList, penCoordinates1);
                
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

        public int y = 10;
        private void syntaxErrorMessage(Exception ex, string lineNum)
        {
            Label label = new Label();
            label.Width = 500;

            label.AutoSize = true;
            label.MaximumSize = new Size(panel1.Width - 20, 0);

            label.Text = ($"An error occurred: {ex.Message} {lineNum}");
            label.Location = new Point(10, y);
            panel1.Controls.Add(label);

            y += label.Height + 2;
        }

        bool multiThread = false;

        /// <summary>
        /// Event handler for the run button.
        /// Processes and executes each line.
        /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            /// <param name="sender">The object that raised the event.</param>
            /// <param name="e">The event arguments.</param>
            /// <remarks>
            /// This method is an event handler for the run button. It processes and executes
            /// commands entered in TextBox1 and TextBox3. It performs syntax
            /// checking using a syntaxChecker instance and displays error messages for syntax errors. 
            /// Multi-threading is performe if textbox2 also has text.
            /// </remarks>
           
            List<string> multiLine2 = Parser.multiLineProcess(textBox3);
            List<string> multiLine1 = Parser.multiLineProcess(textBox1);
            bool syntaxErrors = false;

            syntaxChecker syntaxChecker = new syntaxChecker();


            try{
                syntaxChecker.CheckMethodDecleration(multiLine1);
            }
            catch (Exception ex)
            {
                syntaxErrorMessage(ex, "method");
                syntaxErrors = true;
            }

            try
            {
                syntaxChecker.CheckIfDecleration(multiLine1);
            }
            catch (Exception ex)
            {
                syntaxErrorMessage(ex, "if");
                syntaxErrors = true;
            }

            try
            {
                syntaxChecker.CheckWhileDecleration(multiLine1);
            }
            catch (Exception ex)
            {
                syntaxErrorMessage(ex, "while");
                syntaxErrors = true;
            }

            for (int i = 0; i < multiLine1.Count; i++)
            {
                List<string> commandList = multiLine1[i].Split(' ').ToList();
               try
               {
                    syntaxChecker.CheckVariableDeclaration(commandList);
               }catch(Exception ex)
               {
                   syntaxErrorMessage(ex, ("line"+i.ToString()));
                   syntaxErrors = true;
               }
            }


                if (!syntaxErrors)
            {
                if (multiLine2.Count == 0)
                {
                    multiThread = false;
                    ProcessCommands(multiLine1, penCoordinates1);
                }
                else
                {
                    multiThread = true;
                    Thread thread1 = new Thread(() =>
                    {


                        if (multiLine1[0] != "error")
                        {

                            ProcessCommands(multiLine1, penCoordinates1);


                        }
                    });


                    Thread thread2 = new Thread(() =>
                    {
                        if (multiLine2[0] != "error")
                        {

                            ProcessCommands(multiLine2, penCoordinates2);

                        }
                    });
                    thread1.Start();
                    thread2.Start();
                }
            }
          
        }


        /// <summary>
        /// Processes a list of commands and executes them based on specified conditions.
        /// </summary>
        /// <param name="multiLine">The list of commands to be processed.</param>
        /// <param name="penCoordinates">The coordinates for drawing operations.</param>
        public void ProcessCommands(List<string> multiLine, List<int> penCoordinates)
        {
            bool ifAchieved = true;
            bool methodBool = false;
            int loopStartLine = 0;
            int loopEndLine = 0;
            List<string> methodCommands = new List<string>();
            string methodName = " ";

            MethodFactory methodFactory = new MethodFactory();

            if (multiLine[0] == "error")
            {
          
            }
            else
            {

                for (int i = 0; i < multiLine.Count; i++)
                {
                    List<string> commandList = multiLine[i].Split(' ').ToList();

                    if (commandList[0] == "while")
                    {
                        if (commands.ifstatment(commandList))
                        {
                            loopStartLine = i - 1;
                        }
                        else
                        {
                            i = loopEndLine;
                        }
                    }
                    else if (commandList[0] == "endloop")
                    {
                        loopEndLine = i;
                        i = loopStartLine;
                    }

                    if (commandList[0] == "method")
                    {
                        methodBool = true;
                        methodName = commandList[1];
                    }

                    if (commandList[0] == "if")
                    {
                        ifAchieved = commands.ifstatment(commandList);
                    }
                    else if (commandList[0] == "endif")
                    {
                        ifAchieved = true;
                    }

                    if (ifAchieved == true && methodBool == false)
                    {
                        if (Parser.methodsProcess != null && Parser.methodsProcess.ContainsKey(commandList[0]))
                        {
                            methodFactory.UseParameter(commandList, Parser.methodParameters);
                            executeMethod(Parser.methodsProcess[commandList[0]]);
                        }
                        else
                        {
                            
                            executeLine(commandList, penCoordinates);

                            if (multiThread)
                            {
                                Thread.Sleep(1000);
                            }
                        }
                    }

                    if (methodBool == true)
                    {
                        methodCommands.Add(multiLine[i]);
                    }

                    if (commandList[0] == "endmethod")
                    {
                        Method newMethod = methodFactory.CreateMethod(methodName, methodCommands);
                        Parser.methodsProcess[newMethod.Name] = newMethod.commands;
                        string result = string.Join(" ", Parser.methodsProcess[newMethod.Name]);
                        methodBool = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executes a series of commands from the method.
        /// </summary>
        /// <param name="commandList">The list of commands to be executed.</param>
        public void executeMethod (List<string> commandList)
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                List<string> commandLineList = commandList[i].Split(' ').ToList();
                executeLine(commandLineList, penCoordinates1);
            }
        }

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
