using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    internal class Method
    {
        /// <summary>
        /// Instance of the VariableFactory class for creating variables.
        /// </summary>
        VariableFactory variableFactory = new VariableFactory();
        public string Name { get; set; }
        public List<string> commands { get; set; }
        public List<string> parameters = new List<string>();

        /// <summary>
        /// Extracts parameter names from the method declaration and initializes parameters.
        /// </summary>
        /// <param name="commands">List of commands representing the method proccesses.</param>
        /// <returns>List of parameter names.</returns>
        public List<string> parameterDecleration (List<string> commands)
        {
            string result = string.Join(" ", commands);
            if (commands[2].Length > 2)
            {
                string ParameterNames = commands[2].TrimStart('(').TrimEnd(')');
                List<string> ParameterNamesList = ParameterNames.Split(',').ToList();

                parameters = ParameterNamesList;

                for (int i = 0; i < ParameterNamesList.Count; i++)
                {
                    Variable variableDecleration = variableFactory.CreateVariable(parameters[i].ToString(), 0);
                    Parser.variables[variableDecleration.Name] = variableDecleration.Value;
                }

                return parameters;


            }
            return null;
        }

        /// <summary>
        /// Sets parameter values based on the method call and updates variables accordingly.
        /// </summary>
        /// <param name="commands">List of commands representing the method call.</param>
        /// <param name="parameterNames">List of parameter names for the method.</param>
        public void ParameterUse (List<string> commands, List<string> parameterNames)
        {
            
            //MessageBox.Show(result + "4444");
            if (commands[1].Length > 2)
            {
                string ParameterNames = commands[1].TrimStart('(').TrimEnd(')');
                List<string> ParameterValueList = ParameterNames.Split(',').ToList();

                for (int i = 0; i < ParameterValueList.Count; i++)
                {
                    string result = string.Join(" ", parameters).ToString();
                    Variable variableDecleration = variableFactory.CreateVariable(parameterNames[i], int.Parse(ParameterValueList[i]));
                    Parser.variables[variableDecleration.Name] = variableDecleration.Value;
                }

            }
            

        }
    }
}
