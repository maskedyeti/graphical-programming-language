using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    public interface IVariableFactory
    {
        /// <summary>
        /// Creates a new variable with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The initial value of the variable.</param>
        /// <returns>A new instance of variable
        Variable CreateVariable(string name, int value);
    }
    public class VariableFactory : IVariableFactory
    {
        public Variable CreateVariable(string name, int value)
        {
            return new Variable { Name = name, Value = value };
        }

        /// <summary>
        /// Creates a new variable and performs a mathematical operation based on the specified parameters.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The initial value of the variable.</param>
        /// <param name="operand1">The first operand for the mathematical operation.</param>
        /// <param name="operand2">The second operand for the mathematical operation.</param>
        /// <param name="operation">The mathematical operation to perform ('+', '-', '*').</param>
        public Variable MathsVariable(string name, int value, int operand1, int operand2, string operation) 
        {
            

            Variable variable = new Variable { Name = name, Value = value };

            if (operation == "-")
            {
                variable.Subtract(operand1, operand2);

            }else if (operation == "+")
            {
                variable.Add(operand1, operand2);
               

            }else if (operation == "*")
            {
                variable.multiplication(operand1, operand2);

            }

            return variable;
        }
    }
}
