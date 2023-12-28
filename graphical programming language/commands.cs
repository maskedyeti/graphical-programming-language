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
    public class commands



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



        public static void moveTo(List<int> coordinates, int xCoordinates, int yCoordinates) //change location of "paintbrush" panel 

        {

            coordinates[0] = xCoordinates;

            coordinates[1] = yCoordinates;



        }



        public static void circle(Graphics g, int xCoordinates, int yCoordinates, int radius, Boolean fill)

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

        public static void drawto(Graphics g, List<int> coordinates, int newXcoordinates, int newYcoordinates)

        {

            Point originalPoints = new Point(coordinates[0], coordinates[1]);

            Point drawtoPoints = new Point(newXcoordinates, newYcoordinates);



            g.DrawLine(commands.DrawingPen, originalPoints, drawtoPoints);

            moveTo(coordinates, newXcoordinates, newYcoordinates); //moves paintbrush with line 


        }

        public static bool ifstatment(List<string> commandList)
        {
            if (int.TryParse(commandList[1], out int num1) && int.TryParse(commandList[3], out int num2)) //checks if 2 numbers are equal
            {
                if (num1 == num2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if (Parser.variables.ContainsKey(commandList[1]) && int.TryParse(commandList[3], out int num21))
            {
                if (Parser.variables[commandList[1]] == num21)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if(int.TryParse(commandList[1], out int num11) && Parser.variables.ContainsKey(commandList[3]))
            {
                if (Parser.variables[commandList[3]] == num11)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if(Parser.variables.ContainsKey(commandList[1]) && Parser.variables.ContainsKey(commandList[3]))
            {
                if (Parser.variables[commandList[1]] == Parser.variables[commandList[3]])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else
            {
                return false;
            }

        }
    }

}

