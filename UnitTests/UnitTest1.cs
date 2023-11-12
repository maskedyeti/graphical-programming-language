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



    }
}
