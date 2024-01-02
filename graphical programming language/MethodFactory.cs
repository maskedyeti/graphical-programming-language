using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace graphical_programming_language
{


    internal class MethodFactory
    {
        Method method = new Method();
        public Method CreateMethod(string name, List<string> commands)
        {
            
            method.Name = name;
            method.commands = commands;

            // method.parameterDecleration(commands);

            return method;
        }

        public void UseParameter(List<string> commands, List<string> parameterNames)
        {
            method.ParameterUse(commands, parameterNames);
        }
        
        public List<string> DeclareParameter(List<string> commands)
        {
            List<string> results = method.parameterDecleration(commands);
            return results;
        }
    }
}
