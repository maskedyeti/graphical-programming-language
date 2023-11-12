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

    ///<summary>
    ///commands class holds all of the relevant drawing and opperational commands for the program
    ///</summary>
    public class commands



    {

        public static Pen DrawingPen { get; private set; }

        public static SolidBrush DrawingBrush { get; private set; }


        ///<summary>
        ///initialises the pen the rbush and sets the colour as black
        ///</summary>
        public static void DrawingManager()

        {

            // Initialize the Pen/brush with the default color (black) 

            DrawingPen = new Pen(Color.Black);

            DrawingBrush = new SolidBrush(Color.Black);

        }


        ///<summary>
        ///sets the colour of the brush and the pen
        ///</summary>
        ///<param name='color'> the users inputted colour </param>
        public static void penColour(Color color)

        {

            // Set the color of the Pen/Brush 

            DrawingPen.Color = color;

            DrawingBrush.Color = color;

        }


        ///<summary> 
        ///draws a rectangle based on the pen coordinates and on the uers inpute
        ///</summary>
        ///<param name='g'> the graphics components</param>
        ///<param name='xCoordinates'> the x coordinates of the pen</param>
        ///<param name='yCoordinates'> the y coordinates of the pen</param>
        ///<param name='hieght'> the height of the rectangle</param>
        ///<param name='width'> the width of the rectangle</param>
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


        /// <summary>
        /// Moves the pen to the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The list containing the current coordinates of the pen</param>
        /// <param name="xCoordinates">The new X-coordinate for the pen</param>
        /// <param name="yCoordinates">The new Y-coordinate for the pen</param>
        public static void moveTo(List<int> coordinates, int xCoordinates, int yCoordinates) //change location of "paintbrush" panel 

        {

            coordinates[0] = xCoordinates;

            coordinates[1] = yCoordinates;



        }


        /// <summary>
        /// Draws a circle to the specified size
        /// </summary>
        /// <param name="g">The graphics object on which to draw the circle.</param>
        /// <param name="xCoordinates">The X coordinate of the center of the circle</param>
        /// <param name="yCoordinates">The Y coordinate of the center of the circle</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="fill">A value indicating whether to fill the circle (true) or draw only the outline (false)</param>
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


        /// <summary>
        /// Draws a triangle
        /// </summary>
        /// <param name="g">The graphics object on which to draw the triangle</param>
        /// <param name="xCoordinates">The X coordinate of the top and bottom-left points of the triangle</param>
        /// <param name="yCoordinates">The Y coordinate of the top and bottom-left points of the triangle</param>
        /// <param name="width">The width of the triangle's base</param>
        /// <param name="height">The height of the triangle</param>
        /// <param name="fill">A value indicating whether to fill the triangle (true) or draw only the outline (false).</param>
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

        /// <summary>
        /// Draws a line from the current position to a new position 
        /// </summary>
        /// <param name="g">The Graphics object on which to draw the lin.</param>
        /// <param name="coordinates">The current position coordinates as a list [X, Y]</param>
        /// <param name="newXcoordinates">The X coordinate of the new position</param>
        /// <param name="newYcoordinates">The Y coordinate of the new position</param>
        public static void drawto(Graphics g, List<int> coordinates, int newXcoordinates, int newYcoordinates)

        {

            Point originalPoints = new Point(coordinates[0], coordinates[1]);

            Point drawtoPoints = new Point(newXcoordinates, newYcoordinates);



            g.DrawLine(commands.DrawingPen, originalPoints, drawtoPoints);

            moveTo(coordinates, newXcoordinates, newYcoordinates); //moves paintbrush with line 


        }


    }

}

