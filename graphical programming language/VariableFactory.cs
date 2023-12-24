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
        Variable CreateVariable(string name, int value);
    }
    public class VariableFactory : IVariableFactory
    {
        public Variable CreateVariable(string name, int value)
        {
            return new Variable { Name = name, Value = value };
        }

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
