using graphical_programming_language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        //processSingleLine tests
        /// <summary>
        /// Unit test to validate the processing of a valid double integer command
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_ValidDoubleIntegerCommand()
        {
            // Arrange
            string command = "moveto 10 20";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "moveto", "10", "20" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of an invalid doubleinteger command
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_InvalidDoubleIntegerCommand()
        {
            // Arrange
            string command = "moveto invalidParameter";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "invalid/missing parameter, moveto requires 2 integers" }, result);
        }

        /// <summary>
        /// Unit test to test the validation of an invalid command
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_InvalidCommand()
        {
            // Arrange
            string command = "invalid command";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "unrecognised command" }, result);
        }

        /// <summary>
        /// Unit test to test that an empty input is properly handled
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_EmptyCommand()
        {
            // Arrange
            string command = string.Empty;

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "no command" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of a valid one integer command.
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_ValidOneIntCommand()
        {
            // Arrange
            string command = "circle 20";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "circle", "20" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of an invalid single integer command.
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_InvalidOneIntCommand()
        {
            // Arrange
            string command = "circle invalid";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "invalid/missing parameter circle requires one integer" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of a valid no additional parameter command
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_ValidNoInputCommand()
        {
            // Arrange
            string command = "clear";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "clear" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of an invalid no additional parameter command
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_InvalidNoInputCommand()
        {
            // Arrange
            string command = "clear invalid";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "unnecerssary parameter, clear does not require a parameter" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of a valid string command.
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_ValidStringInputCommand()
        {
            // Arrange
            string command = "pen red";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "pen", "red" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of an invalid string command.
        /// </summary>
        [TestMethod]
        public void ProcessSingleLine_InvalidStringInputCommand()
        {
            // Arrange
            string command = "pen invalid";

            // Act
            List<string> result = Parser.processSingleLine(command);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "invalid/missing parameter pen requires the selection of a 'red', 'blue', 'black', 'green' or 'purple' parameter" }, result);
        }


        //processMultiLine tests
        /// <summary>
        /// Unit test to validate the processing of a of multiple lines of command
        /// </summary>
        [TestMethod]
        public void MultiLineProcess_ValidInput_ShouldReturnCommandLines()
        {
            // Arrange
            var userInput = new TextBox();
            userInput.Multiline = true;
            userInput.Lines = new string[] { "moveto 10 20", "drawto 30 40", "rectangle 50 60" };
            // Act
            List<string> result = Parser.multiLineProcess(userInput);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "moveto 10 20", "drawto 30 40", "rectangle 50 60" }, result);
        }

        /// <summary>
        /// Unit test to validate the processing of multiple lines of commands with errors
        /// </summary>
        [TestMethod]
        public void MultiLineProcess_InputWithErrors_ShouldReturnErrorList()
        {
            // Arrange
            var userInput = new TextBox();
            userInput.Multiline = true;
            userInput.Lines = new string[] { "moveto 10 20", "invalidCommand", "drawto 30 40" };

            // Act
            List<string> result = Parser.multiLineProcess(userInput);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "error", "line 2, unrecognised command" }, result);
        }

        /// <summary>
        /// Unit test to verify that the moveTo method correctly changes the coordinates
        /// </summary>
        [TestMethod]
        public void MoveTo_ShouldChangeCoordinates()
        {
            // Arrange
            List<int> coordinates = new List<int> { 0, 0 };
            int xCoordinates = 10;
            int yCoordinates = 20;

            // Act
            commands.moveTo(coordinates, xCoordinates, yCoordinates);

            // Assert
            Assert.AreEqual(xCoordinates, coordinates[0]);
            Assert.AreEqual(yCoordinates, coordinates[1]);
        }

        /// <summary>
        /// Unit test to verify that the drawto method calls moveTo with the correct arguments.
        /// </summary>
        [TestMethod]
        public void DrawTo_ShouldCallMoveTo()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };
            int newXcoordinates = 30;
            int newYcoordinates = 40;

            // Act
            commands.drawto(graphics, coordinates, newXcoordinates, newYcoordinates);

            // Assert
            Assert.AreEqual(newXcoordinates, coordinates[0]);
            Assert.AreEqual(newYcoordinates, coordinates[1]);

        }

        /// <summary>
        /// Unit test to verify the rectangle method gets called with correct arguments
        /// </summary>
        [TestMethod]
        public void DrawRectangle_Fill_Off()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.rectangle(graphics, coordinates[0], coordinates[1], 5, 5, false);
        }

        /// <summary>
        /// Unit test to verify the rectangle method gets called with correct arguments adn with fill on
        /// </summary>
        [TestMethod]
        public void DrawRectangle_Fill_On()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.rectangle(graphics, coordinates[0], coordinates[1], 5, 5, true);
        }


        /// <summary>
        /// Unit test to verify the circle method gets called with correct arguments
        /// </summary>
        [TestMethod]
        public void DrawCirlce_Fill_Off()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.circle(graphics, coordinates[0], coordinates[1], 5, false);
        }

        /// <summary>
        /// Unit test to verify the circle method gets called with correct arguments and with fill on
        /// </summary>
        [TestMethod]
        public void DrawCirlce_Fill_On()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.circle(graphics, coordinates[0], coordinates[1], 5, true);
        }

        /// <summary>
        /// Unit test to verify the triangle method gets called with correct arguments
        /// </summary>
        [TestMethod]
        public void DrawTriangle_Fill_On()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.triangle(graphics, coordinates[0], coordinates[1], 5, 5, false);
        }

        /// <summary>
        /// Unit test to verify the triangle method gets called with correct arguments and with fill on
        /// </summary>
        [TestMethod]
        public void DrawTriangle_Fill_Off()
        {
            // Arrange
            commands.DrawingManager();
            var bitmap = new Bitmap(20, 20);
            var graphics = Graphics.FromImage(bitmap);
            var coordinates = new List<int> { 10, 10 };

            //Act
            commands.triangle(graphics, coordinates[0], coordinates[1], 5, 5, true);
        }

        /// <summary>
        /// Unit test to verify the calling of the clear method
        /// </summary>
        [TestMethod]
        public void clear()
        {
            // Arrange
            List<string> test = new List<string> { "clear" };
            var Form = new Form1();

            //Act
            Form.executeLine(test);
        }

        /// <summary>
        /// Unit test to verify the calling of the reset method as well as the reset of coordinates
        /// </summary>
        [TestMethod]
        public void reset()
        {
            // Arrange
            List<string> test = new List<string> { "clear" };
            var Form = new Form1();
            List<int> testCoordinates = new List<int> { 10, 10 };

            //Act
            Form.executeLine(test);

            //Assert
            Assert.AreEqual(Form.penCoordinates[0] == 10, Form.penCoordinates[1] == 10);
        }

        /// <summary>
        /// Unit test to verify that executeLine will call for and execute a method
        /// </summary>
        [TestMethod]
        public void ExecuteLine_ShouldCallMoveTo_WhenCommandIsMoveto()
        {
            // Arrange
            var form = new Form1();
            var commandLine = new List<string> { "moveto", "10", "20" };

            // Act
            form.executeLine(commandLine);

        }

        /// <summary>
        /// Unit test to verify that the fill function changes the fill variable when the "fill on" command is given
        /// </summary>
        [TestMethod]
        public void FillShouldChangeFillVariable()
        {
            // Arrange
            var form = new Form1();
            form.fill = false;
            var commandLine = new List<string> { "fill on" };

            // Act
            form.executeLine(commandLine);

            // Assert
            Assert.IsFalse(form.fill);
        }

        /// <summary>
        /// Unit test to verify that the penColour method correctly sets the color of the DrawingPen and DrawingBrush
        /// </summary>
        [TestMethod]
        public void PenColour_ShouldSetPenAndBrushColor()
        {
            // Arrange
            commands.DrawingManager();
            Color expectedColour = Color.Red;

            // Act
            commands.penColour(expectedColour);

            // Assert
            Assert.AreEqual(expectedColour, commands.DrawingPen.Color);
            Assert.AreEqual(expectedColour, commands.DrawingBrush.Color);
        }


     


       
    }




}


