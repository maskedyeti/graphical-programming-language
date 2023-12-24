using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    public class Variable
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public void Subtract(int operand1, int operand2)
        {
            Value = operand1 - operand2;
        }

        public void Add(int operand1, int operand2)
        {
            Value = operand1 + operand2;

        }

        public void multiplication (int operand1, int operand2)
        {
            Value = operand1 * operand2;
        }
    }
}
