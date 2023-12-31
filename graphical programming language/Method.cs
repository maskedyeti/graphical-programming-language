using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace graphical_programming_language
{
    internal class Method
    {
        VariableFactory variableFactory = new VariableFactory();
        public string Name { get; set; }
        public List<string> commands { get; set; }
        public List<string> parameters;

        public void parameterDecleration (List<string> commands)
        {
            if (commands[2].Length > 2)
            {
                string ParameterNames = commands[2].TrimStart('(').TrimEnd(')');
                List<string> ParameterNamesList = ParameterNames.Split(',').ToList();

                parameters = ParameterNamesList;

                
            }
        }

        public List<object> ParameterUse (List<string> commands)
        {
            if (commands[2].Length > 2)
            {
                string ParameterNames = commands[2].TrimStart('(').TrimEnd(')');
                List<string> ParameterValueList = ParameterNames.Split(',').ToList();

                List<object> variables = new List<object>();

                for (int i = 0; i < ParameterValueList.Count; i++)
                {
                    Variable variableDecleration = variableFactory.CreateVariable(parameters[i].ToString(), int.Parse(ParameterValueList[i]));
                    variables.Add(variableDecleration);
                }

                return variables;
            }
            else
            {
                return null;
            }
        }
    }
}
