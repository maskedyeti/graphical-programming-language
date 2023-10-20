using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    class commands
    {
        public static void rectangle(Panel panel, int height, int width, int xCoordinates, int yCoordinates)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, width, height, xCoordinates, yCoordinates);
            }
        }

        public static void paintBrush(Panel panel, int xCoordinates, int yCoordinates) 
        {
            panel.Location = new Point(xCoordinates, yCoordinates);
            
        }
    }
}
