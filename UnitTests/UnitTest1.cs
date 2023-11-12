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




}
}
