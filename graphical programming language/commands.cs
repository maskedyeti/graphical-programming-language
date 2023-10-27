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
                g.DrawEllipse(pen, xCoordinates - radius /2 , yCoordinates - radius /2 , radius , radius ); // /2 centers the rectangle made as the base of the circle around the paintbrush
                                                                                                            
            }
        }

        public static void triangle(Panel panel, int xCoordinates, int yCoordinates, int width, int height)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
                Point[] trianglePoints = new Point[]
                {
                    new Point(xCoordinates, yCoordinates - height), // Top point
                    new Point(xCoordinates, yCoordinates), // Bottom-left point
                    new Point(xCoordinates + width, yCoordinates)  // Bottom-right point
                };
                g.DrawPolygon(pen, trianglePoints);
               
            }
        }
        public static void drawto(Panel panel, Panel paintbrush, int xCoordinates, int yCoordinates, int newXcoordinates, int newYcoordinates)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);

                Point originalPoints = new Point(xCoordinates, yCoordinates);
                Point drawtoPoints = new Point(newXcoordinates, newYcoordinates);

                g.DrawLine(pen, originalPoints, drawtoPoints);
                paintBrush(paintbrush, newXcoordinates, newYcoordinates); //moves paintbrush with line
            }
        }
    }
}
