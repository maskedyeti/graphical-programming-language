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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            commands.paintBrush(panel1, 100, 100);
            if (e.KeyCode == Keys.Enter) 
            {
                List<string> commandList = Parser.processSingleLine(textBox2.Text);

                if (commandList[0] == "error")
                {
                    MessageBox.Show((commandList[1]));
                        
                }
                else
                {
                    //MessageBox.Show(commandList[0]);
                    if ((commandList[0] == "moveto"))
                    {
                        commands.paintBrush(panel1, int.Parse(commandList[1]), int.Parse(commandList[2]));
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            commands.paintBrush(panel1,100, 100);
        }
    }
}
