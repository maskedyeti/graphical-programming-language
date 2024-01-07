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

        //commands tests
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


        [TestMethod]
        public void clear()
        {
            // Arrange
            List<string> test = new List<string> { "clear" };
            var Form = new Form1();

            //Act
            Form.executeLine(test, Form.penCoordinates1);
        }


        [TestMethod]
        public void reset()
        {
            // Arrange
            List<string> test = new List<string> { "clear" };
            var Form = new Form1();
            List<int> testCoordinates = new List<int> { 10, 10 };

            //Act
            Form.executeLine(test, Form.penCoordinates1);

            //Assert
            Assert.AreEqual(Form.penCoordinates1[0] == 10, Form.penCoordinates1[1] == 10);
        }


        [TestMethod]
        public void ExecuteLine_ShouldCallMoveTo_WhenCommandIsMoveto()
        {
            // Arrange
            var form = new Form1();
            var commandLine = new List<string> { "moveto", "10", "20" };

            // Act
            form.executeLine(commandLine, form.penCoordinates1);

        }


        [TestMethod]
        public void Fill_Should_Change_Fill_Variable()
        {
            // Arrange
            var form = new Form1();
            form.fill = false;
            var commandLine = new List<string> { "fill on" };

            // Act
            form.executeLine(commandLine, form.penCoordinates1);

            // Assert
            Assert.IsFalse(form.fill);
        }


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


       // [TestMethod]
       // public void Button3_Click_ShouldLoadFileContentsIntoTextBox()
      //  {
            // Arrange
        //    var form = new Form1();

            // Act

         //  form.button3_Click(null, EventArgs.Empty);

             //Assert
         //   Assert.AreEqual("test", form.textBox1.Text);
      //  }



        //section 2 tests

        //variables
        [TestMethod]
        public void TestVariableDeclaration()
        {
            // Arrange
            Form1 form = new Form1();
            Parser pasrer = new Parser();
            List<string> inputCode = new List<string>{ "myVar", "=", "10" };

            // Act
            form.executeLine(inputCode, form.penCoordinates1);

            // Assert
            Assert.AreEqual(10, Parser.variables["myVar"]);
        }
    }




}


