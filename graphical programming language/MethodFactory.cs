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

        /// <summary>
        /// Creates a new Method instance with the specified name and commands.
        /// </summary>
        /// <param name="name">The name of the method.</param>
        /// <param name="commands">The list of commands within the method.</param>
        /// <returns>A new Method instance.</returns>
        public Method CreateMethod(string name, List<string> commands)
        {
            
            method.Name = name;
            method.commands = commands;

            // method.parameterDecleration(commands);

            return method;
        }

        /// <summary>
        /// Uses parameter values in the specified commands to update the Method parameters.
        /// </summary>
        /// <param name="commands">The list of commands representing the method call.</param>
        /// <param name="parameterNames">The list of parameter names for the method.</param>
        public void UseParameter(List<string> commands, List<string> parameterNames)
        {
            method.ParameterUse(commands, parameterNames);
        }

        /// <summary>
        /// Declares parameters based on the specified commands and updates the Method instance's parameters.
        /// </summary>
        /// <param name="commands">The list of commands representing the method declaration.</param>
        /// <returns>The list of parameter names declared in the method.</returns>
        public List<string> DeclareParameter(List<string> commands)
        {
            List<string> results = method.parameterDecleration(commands);
            return results;
        }
    }
}
