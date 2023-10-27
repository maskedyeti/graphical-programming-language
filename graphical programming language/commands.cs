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
        public static void rectangle(Panel panel, int xCoordinates, int yCoordinates, int height, int width)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen,xCoordinates, yCoordinates, height, width);
            }
        }

        public static void paintBrush(Panel panel, int xCoordinates, int yCoordinates) 
        {
            panel.Location = new Point(xCoordinates, yCoordinates);
            
        }

        public static void circle (Panel panel, int xCoordinates, int yCoordinates, int radius)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
                g.DrawEllipse(pen, xCoordinates - radius /2 , yCoordinates - radius /2 , radius , radius );
            }
        }

        public static void triangle(Panel panel, int xCoordinates, int yCoordinates, int width, int height)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
               
            }
        }
    }
}
