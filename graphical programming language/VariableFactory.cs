using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
