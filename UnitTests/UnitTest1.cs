using graphical_programming_language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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



    }



}

