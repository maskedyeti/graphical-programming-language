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
        VariableFactory variableFactory = new VariableFactory();
        public string Name { get; set; }
        public List<string> commands { get; set; }
        public List<string> parameters = new List<string>();

        public List<string> parameterDecleration (List<string> commands)
        {
            string result = string.Join(" ", commands);
            MessageBox.Show(result+"3333");
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
                    MessageBox.Show(result + "4444");
                    Variable variableDecleration = variableFactory.CreateVariable(parameterNames[i], int.Parse(ParameterValueList[i]));
                    Parser.variables[variableDecleration.Name] = variableDecleration.Value;
                }

            }
            

        }
    }
}
