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
        public static Pen DrawingPen { get; private set; }
        public static SolidBrush DrawingBrush { get; private set; }

        public static void DrawingManager()
        {
            // Initialize the Pen/brush with the default color (black)
            DrawingPen = new Pen(Color.Black);
            DrawingBrush = new SolidBrush(Color.Black);
        }

        public static void penColour(Color color)
        {
            // Set the color of the Pen/Brush
            DrawingPen.Color = color;
            DrawingBrush.Color = color;
        }

        public static void rectangle(Graphics g, int xCoordinates, int yCoordinates, int height, int width, bool fill)
        {
            if (fill == false) //draws outline
            {
                g.DrawRectangle(DrawingPen, xCoordinates, yCoordinates, height, width);
            }
            else //draws filled out shape
            {
                g.FillRectangle(DrawingBrush, xCoordinates, yCoordinates, height, width);
            }
        }

            public static void paintBrush(Panel panel, int xCoordinates, int yCoordinates) //change location of "paintbrush" panel
        {
            panel.Location = new Point(xCoordinates, yCoordinates);
            
        }

        public static void circle (Graphics g, int xCoordinates, int yCoordinates, int radius, Boolean fill)
        {
            if (fill == false)
            {
                g.DrawEllipse(commands.DrawingPen, xCoordinates - radius / 2, yCoordinates - radius / 2, radius, radius); // /2 centers the rectangle made as the base of the circle around the paintbrush
            }
            else
            {
                g.FillEllipse(commands.DrawingBrush, xCoordinates - radius / 2, yCoordinates - radius / 2, radius, radius);
            }
        }

        public static void triangle(Graphics g, int xCoordinates, int yCoordinates, int width, int height, Boolean fill)
        {
            Point[] trianglePoints = new Point[]
            {
                new Point(xCoordinates, yCoordinates - height), // Top point
                new Point(xCoordinates, yCoordinates), // Bottom-left point
                new Point(xCoordinates + width, yCoordinates)  // Bottom-right point
            };
          
            if (fill == false)
            {
                g.DrawPolygon(commands.DrawingPen, trianglePoints);
            }
            else
            {
                g.FillPolygon(commands.DrawingBrush, trianglePoints);
            }  
        }
        public static void drawto(Graphics g, Panel paintbrush, int xCoordinates, int yCoordinates, int newXcoordinates, int newYcoordinates)
        {
            Point originalPoints = new Point(xCoordinates, yCoordinates);
            Point drawtoPoints = new Point(newXcoordinates, newYcoordinates);

            g.DrawLine(commands.DrawingPen, originalPoints, drawtoPoints);
            paintBrush(paintbrush, newXcoordinates, newYcoordinates); //moves paintbrush with line
            
        }
    }
}
