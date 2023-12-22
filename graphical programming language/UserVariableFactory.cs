using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphical_programming_language
{
    public interface IVariableFactory
    {
        IVariable CreateVariable(string name, int value);
    }
    public class UserVariableFactory : IVariableFactory
    {
        public IVariable CreateVariable(string name, int value)
        {
            return new UserVariable(name, value);
        }
    }
}
