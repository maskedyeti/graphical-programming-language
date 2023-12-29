using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace graphical_programming_language
{
    public class Parser //handles input processing and input validation
    {
        public static Dictionary<string, int> variables = new Dictionary<string, int>();
      
        VariableFactory variableFactory = new VariableFactory();
      
        

        static List<string> validCommands = new List<string> { "moveto", "drawto", "clear", "reset", "rectangle"
                                                        , "circle", "triangle", "pen", "fill", "if", "endif", "while", "endloop"};

        //contains commands and their requiredparameters for input validation
        static List<string> twoIntCommands = new List<string> {"moveto", "drawto", "rectangle", "triangle"}; 
        static List<string> noInputCommands = new List<string> {"clear", "reset", "run"};
        static List<string> oneIntCommands = new List<string> { "circle" };
        static List<string> stringCommands = new List<string> { "pen", "fill"};
        public static List<string> operations = new List<string> {"-", "+", "*"};
        static List<string> validColour = new List<string> { "red", "blue", "black", "green", "purple" };
  
        public static List<string> processSingleLine(String command)//method to split inputted line of command into a list and validate it
        {
            List<string> errorList = new List<string> {"empty", "empty"};
            Parser parser = new Parser();

            bool commandEmpty = string.IsNullOrWhiteSpace(command);//checks if the their is a command present

            if (commandEmpty == true) 
            {
                errorList[0] = "error";
                errorList[1] = "no command";

            }

            else if (commandEmpty == false)
            {
                List<string> commandList = command.Split(' ').ToList(); //splits list based off space 
                if (validCommands.Contains(commandList[0]))
                {
                
                    if (twoIntCommands.Contains(commandList[0])) //two integer command and parameter validation
                    {

                        if (commandList.Count == 3)
                        {
                            //MessageBox.Show(variables[commandList[1]].ToString());
                            if (int.TryParse(commandList[1], out _) && int.TryParse(commandList[2], out _)) //checks if both additional parameters are numbers
                            {

          
                            }
                            
                            else if (variables.ContainsKey(commandList[1]) && int.TryParse(commandList[2], out _))
                            {
                                
                                //commandList[1] = variables[commandList[1]].ToString();
                            }
                            else if (variables.ContainsKey(commandList[2]) && int.TryParse(commandList[1], out _))
                            {
                                //commandList[2] = variables[commandList[2]].ToString();
                            }
                            else if (variables.ContainsKey(commandList[2]) && variables.ContainsKey(commandList[1]))
                            {
                                //commandList[2] = variables[commandList[2]].ToString();
                                //commandList[1] = variables[commandList[1]].ToString();
                            }
                            else
                            {
                                errorList[0] = "error";
                                errorList[1] = "invalid/missing parameter, " + commandList[0] + " requires 2 integers or a valid variable";
                            }
                        }
                        else
                        {
                            errorList[0] = "error";
                            errorList[1] = "invalid/missing parameter, " + commandList[0] + " requires 2 integers";
                        }
                    }

                    if (noInputCommands.Contains(commandList[0])) //no additional input command and parameter validation
                    {
                        if (commandList.Count == 1)
                        {
                        }
                        else
                        {
                            errorList[0] = "error";
                            errorList[1] = "unnecerssary parameter, " + commandList[0] + " does not require a parameter";
                        }
                    }

                    if (oneIntCommands.Contains(commandList[0]))//one integer command and parameter validation
                    {
                        if (commandList.Count == 2)
                        {
                            if (int.TryParse(commandList[1], out _))
                            {
                            } else if (variables.ContainsKey(commandList[1]))
                            {
                                //commandList[1] = variables[commandList[1]].ToString();
                            }
                            else
                            {
                                errorList[0] = "error";
                                errorList[1] = "invalid/missing parameter " + commandList[0] + " requires one integer";
                            }
                        }
                        else 
                        {
                            errorList[0] = "error";
                            errorList[1] = "invalid/missing parameter " + commandList[0] + " requires one integer";
                        }
                    }

                    if (stringCommands.Contains(commandList[0]))
                    {
                        if (commandList[0] == "fill")
                        {
                            if (commandList[1] == "on")
                            {
                            }
                            else if (commandList[1] == "off")
                            {
                            }
                            else
                            {
                                errorList[0] = "error";
                                errorList[1] = "invalid/missing parameter " + commandList[0] + " requires either an 'on' or 'off' parameter selection";
                            }
                        }

                        if (commandList[0] == "pen")
                        {
                            if (validColour.Contains(commandList[1]))
                            {
                            }
                            else
                            {
                                errorList[0] = "error";
                                errorList[1] = "invalid/missing parameter " + commandList[0] + " requires the selection of a 'red', 'blue', 'black', 'green' or 'purple' parameter";
                            }
                        }
                    }

                }else if(commandList.Count() == 3 && commandList[1] == "=")
                {
                    if (int.TryParse(commandList[2], out int value))
                    {

                        variables[commandList[0]] = 0;

                    }
                    else
                    {
                        errorList[0] = "error";
                        errorList[1] = "error, variable can only be declared as an integer";
                    }
                    
                }else if(commandList.Count() == 5 && commandList[1] == "=" && operations.Contains(commandList[3]))
                {

                    if (int.TryParse(commandList[2], out int operand1) && int.TryParse(commandList[4], out int operand2))
                    {

                        //Variable a = parser.variableFactory.MathsVariable(commandList[0], 0, operand1, operand2, commandList[3]);
                        //variables[a.Name] = a.Value;

                    }else if (variables.ContainsKey(commandList[2]) && int.TryParse(commandList[4], out int operand2a))
                    {
                        //Variable a = parser.variableFactory.MathsVariable(commandList[0], 0, variables[commandList[2]], operand2a, commandList[3]);
                        //variables[a.Name] = a.Value;
                       
                    }
                    else if (variables.ContainsKey(commandList[4]) && int.TryParse(commandList[2], out int operand1a))
                    {
                        //Variable a = parser.variableFactory.MathsVariable(commandList[0], 0, operand1a, variables[commandList[4]], commandList[3]);
                        //variables[a.Name] = a.Value;
                    }

                }else if (commandList[0] == "if")
                {
                    if (commandList[2] == "=" || commandList[2] == ">" || commandList[2] == "<")
                    {
                        if (int.TryParse(commandList[1], out _) || variables.ContainsKey(commandList[1]))
                        {
                        }
                        else
                        {
                            errorList[0] = "error";
                            errorList[1] = "error first parameter for if statment is invalid";
                        }

                        if (int.TryParse(commandList[3], out _) || variables.ContainsKey(commandList[3]))
                        {
                            errorList[0] = "error";
                            errorList[1] = "error second parameter for if statment is invalid";
                        }
                    }
                    else
                    {
                        errorList[0] = "error";
                        errorList[1] = "error, improper format of if statment. requires a '=, <, >'";
                    }
                }
                else
                {
                    
                    errorList[0] = "error";
                    errorList[1] = "unrecognised command";
                }
                if (errorList[0] == "error")
                {
                    return errorList;
                }
                else
                {
                    return commandList;
                }
            }
            return errorList;
        }

        public static List<string> multiLineProcess(System.Windows.Forms.TextBox userInput) //breaks down each line into a list element after validating
        {

            List<string> commandLines = new List<string> (); //stores singular lines of command after validation
            List<string> errorList = new List<string> {"error"};
            string[] lines = userInput.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                List<string> lineCommandList = Parser.processSingleLine(lines[i]); //validates singular line
                string lineCommandString = string.Join(" ", lineCommandList);

                if (lineCommandList[0] == "error")
                {
                    int lineNumber = i + 1;
                    errorList.Add("line " + lineNumber.ToString() + ", " + lineCommandList[1]);
                }
                else
                {
                    commandLines.Add(lineCommandString);
                }
                
            }

            if (errorList.Count > 1)
            {
                return errorList;
            }
            else
            {
                return commandLines;
            }
        }
    }
}
