using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// forms variables and performs mathematical operations.
/// </summary>
namespace graphical_programming_language
{
    public class Variable
    {
        public string Name { get; set; }
        public int Value { get; set; }


        /// <summary>
        /// Subtracts two numbers and assigns the result to the variable's value.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        public void Subtract(int operand1, int operand2)
        {
            Value = operand1 - operand2;
        }

        /// <summary>
        /// Multiplies two numbers and assigns the result to the variable's value.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        public void Add(int operand1, int operand2)
        {
            Value = operand1 + operand2;

        }

        /// <summary>
        /// Multiplies two numbers and assigns the result to the variable's value.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        public void multiplication (int operand1, int operand2)
        {
            Value = operand1 * operand2;
        }
    }
}
