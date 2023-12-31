﻿using graphical_programming_language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static graphical_programming_language.syntaxChecker;


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

        //variables tests
        [TestMethod]
        public void TestVariableDeclaration()
        {
            // Arrange
            Form1 form = new Form1();
            Parser pasrer = new Parser();
            List<string> inputCode = new List<string> { "myVar", "=", "10" };

            // Act
            form.executeLine(inputCode, form.penCoordinates1);

            // Assert
            Assert.AreEqual(10, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestVariableDeclarationWithEquation()
        {
            // Arrange
            Form1 form = new Form1();
            Parser pasrer = new Parser();
            List<string> inputCode = new List<string> { "myVar", "=", "10", "-", "5" };

            // Act
            form.executeLine(inputCode, form.penCoordinates1);

            // Assert
            Assert.AreEqual(5, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestVariableDeclarationWithVariable()
        {
            // Arrange
            Form1 form = new Form1();
            Parser pasrer = new Parser();
            List<string> inputCode1 = new List<string> { "myVar", "=", "10" };
            List<string> inputCode2 = new List<string> { "myVar", "=", "myVar", "-", "5" };

            // Act
            form.executeLine(inputCode1, form.penCoordinates1);
            form.executeLine(inputCode2, form.penCoordinates1);

            // Assert
            Assert.AreEqual(5, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestVariablesUsedAsParameters()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "myVar", "=", "50" };
            List<string> inputCode2 = new List<string> { "rectanlge", "myVar", "myVar" };

            // Act
            form.executeLine(inputCode1, form.penCoordinates1);
            form.executeLine(inputCode2, form.penCoordinates1);

        }



        //if statment tests
        [TestMethod]
        public void TestValidIfstatment()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "myVar = 10", "if myVar = 10", "myVar = 15", "endif" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(15, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestInvalidIfstatment()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "myVar = 10", "if myVar = 1", "myVar = 15", "endif" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(10, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestVariablesIfstatment()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "myVar = 10", "myVar2 = 10", "if myVar = myVar2", "myVar = 15", "endif" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(15, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestIfStatmentWithComplexExpression()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "myVar = 5", "myVar2 = 10", "if myVar < myVar2", "myVar = 15", "endif" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(15, Parser.variables["myVar"]);
        }



        //loop tests
        [TestMethod]
        public void TestLoop()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "counter = 0", "while counter < 5", "counter = counter + 1", "endloop" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(5, Parser.variables["counter"]);
        }



        //method unit tests
        [TestMethod]
        public void TestMethodNoParameter()
        {
            // Arrange
            Form1 form = new Form1();
            List<string> inputCode1 = new List<string> { "method var ()", "myVar = 5", "endmethod", "var ()" };

            // Act
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(5, Parser.variables["myVar"]);
        }

        [TestMethod]
        public void TestMethodWithParameter()
        {
            // Arrange
            Form1 form = new Form1();       
            List<string> inputCode1 = new List<string> { "method bigVar (a,b)", "myVar = a * b", "endmethod", "bigVar (10,10)" };

            // Act
            Parser.processSingleLine(inputCode1[0]);
            form.ProcessCommands(inputCode1, form.penCoordinates1);

            //assert
            Assert.AreEqual(100, Parser.variables["myVar"]);
        }



        //syntax checker

        [TestMethod]
        public void CheckVariableDeclarationInvalidVariableNameThrowsException()
        {
            syntaxChecker syntaxChecker = new syntaxChecker();
            List<string> commandList = new List<string> { "10", "=", "value" };

            Assert.ThrowsException<InvalidVariableNameException>(() =>
                syntaxChecker.CheckVariableDeclaration(commandList));
        }

        [TestMethod]
        public void CheckVariableDeclaration_InvalidVariableValue_ThrowsException()
        {
            syntaxChecker syntaxChecker = new syntaxChecker();
            List<string> commandList = new List<string> { "myVar", "=", "invalidValue" };
            syntaxChecker syntaxCheck = new syntaxChecker();

            Assert.ThrowsException<InvalidVariableValueDeclerationException>(() =>
                syntaxChecker.CheckVariableDeclaration(commandList));
        }

        [TestMethod]
        public void CheckMethodDeclaration_InvalidMethodDeclaration_ThrowsException()
        {
            syntaxChecker syntaxChecker = new syntaxChecker();
            List<string> multiLine = new List<string> { "method", "methodName", "param1", "param2" };

            Assert.ThrowsException<InvalidMethodDeclerationException>(() =>
                syntaxChecker.CheckMethodDecleration(multiLine));
        }

        [TestMethod]
        public void CheckIfDeclaration_InvalidIfDeclaration_ThrowsException()
        {
            syntaxChecker syntaxChecker = new syntaxChecker();
            List<string> multiLine = new List<string> { "if a = b", "endif" };

            Assert.ThrowsException<IfInvalidOperatorException>(() =>
                syntaxChecker.CheckIfDecleration(multiLine));
        }

        [TestMethod]
        public void CheckWhileDeclaration_NoEndWhile_ThrowsException()
        {
            syntaxChecker syntaxChecker = new syntaxChecker();
            List<string> multiLine = new List<string> { "while 10 = 10" };

            Assert.ThrowsException<NoEndWhileException>(() =>
                syntaxChecker.CheckWhileDecleration(multiLine));
        }



        //multithreading

        [TestMethod]
        public void TestButton1Click()
        {
            // Arrange
            Form1 form = new Form1(); 
            TextBox textBox1 = new TextBox();
            TextBox textBox3 = new TextBox();

            textBox1.Text = "a = 0";
            textBox3.Text = "b = 0";

            form.textBox1 = textBox1;
            form.textBox3 = textBox3;

            // Act
            form.button1_Click(null, EventArgs.Empty);

            // Assert

            Assert.AreEqual(0, Parser.variables["a"]);
            Assert.AreEqual(0, Parser.variables["b"]);
        }



        //rotating shapes

        [TestMethod]
        public void RotateRectangle()
        {
            //arrange
            var bitmap = new Bitmap(1, 1);
            var g = Graphics.FromImage(bitmap);
            commands commands = new commands();

            //act
            commands.DrawRotatedRectangle(g, 10, 10, 50, 50, 45);
        }

        [TestMethod]
        public void RotateTriangle()
        {
            //arrange
            var bitmap = new Bitmap(1, 1);
            var g = Graphics.FromImage(bitmap);
            commands commands = new commands();

            //act
            commands.DrawRotatedTriangle(g, 10, 10, 50, 50, 45);
        }
    }
}







