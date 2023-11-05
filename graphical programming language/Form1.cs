using System;
using System.Collections.Generic;
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

        private Boolean fill = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void executeLine(List<string> commandLine)
        {
            List<string> commandList = commandLine;

            if (commandList[0] == "error")
            {
                MessageBox.Show((commandList[1]));

            }
            else
            {
                if ((commandList[0] == "moveto"))
                {
                    commands.paintBrush(paintBrushPanel, int.Parse(commandList[1]), int.Parse(commandList[2]));
                }
                else if ((commandList[0]) == "rectangle")
                {
                    commands.rectangle(panel1, paintBrushPanel.Location.X, paintBrushPanel.Location.Y,
                                                        int.Parse(commandList[1]), int.Parse(commandList[2]), fill);
                }
                else if ((commandList[0]) == "clear")
                {
                    panel1.Invalidate();
                }
                else if ((commandList[0]) == "circle")
                {
                    commands.circle(panel1, paintBrushPanel.Location.X, paintBrushPanel.Location.Y, int.Parse(commandList[1]), fill);
                }
                else if (commandList[0] == "triangle")
                {
                    commands.triangle(panel1, paintBrushPanel.Location.X, paintBrushPanel.Location.Y,
                                                        int.Parse(commandList[1]), int.Parse(commandList[2]), fill);
                }
                else if ((commandList[0]) == "drawto")
                {
                    commands.drawto(panel1, paintBrushPanel, paintBrushPanel.Location.X, paintBrushPanel.Location.Y,
                                                        int.Parse(commandList[1]), int.Parse(commandList[2]));
                }
                else if ((commandList[0]) == "pen")
                {
                    commands.penColour(Color.FromName(commandList[1]));
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
                    label.MaximumSize = new System.Drawing.Size(panel1.Width - 20, 0);

                    label.Text = multiLine[i];
                    label.Location = new Point(10, y);
                    panel1.Controls.Add(label);

                    y += label.Height + 2;
                }
            }
        }
    }
}
