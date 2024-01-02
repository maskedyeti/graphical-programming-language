using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphical_programming_language
{


    internal class MethodFactory
    {
        public Method CreateMethod(string name, List<string> commands)
        {
            Method method = new Method();
            method.Name = name;
            method.commands = commands;

            method.parameterDecleration(commands);

            return method;
        }

        
    }
}
