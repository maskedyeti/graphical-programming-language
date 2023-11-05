using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
        static List<string> validCommands = new List<string> { "moveto", "drawto", "clear", "reset", "rectangle"
                                                        , "circle", "triangle", "pen", "fill"};

        //contains commands and their requiredparameters for input validation
        static List<string> twoIntCommands = new List<string> {"moveto", "drawto", "rectangle", "triangle"}; 
        static List<string> noInputCommands = new List<string> {"clear", "reset", "run"};
        static List<string> oneIntCommands = new List<string> { "circle" };
        static List<string> stringCommands = new List<string> { "pen", "fill"};

        static List<string> validColour = new List<string> { "red", "blue", "black", "green", "purple" };

        public static List<string> processSingleLine(String command)//method to split inputted line of command into a list and validate it
        {
            List<string> commandList = new List<string> {"empty", "empty"};

            bool commandEmpty = string.IsNullOrWhiteSpace(command);//checks if the their is a command present

            if (commandEmpty == true) 
            {
                commandList[0] = "error";
                commandList[1] = "unknown command";

            }

            else if (commandEmpty == false)
            {
                commandList = command.Split(' ').ToList(); //splits list based off space 

                if (validCommands.Contains(commandList[0]))
                {
                    if (twoIntCommands.Contains(commandList[0])) //two integer command and parameter validation
                    {
                        if (commandList.Count == 3)
                        {
                            if (int.TryParse(commandList[1], out _) == true)
                            {
                                if (int.TryParse(commandList[2], out _) == true)

                                {
                                }
                                else
                                {
                                    commandList[0] = "error";
                                    commandList[1] = "invalid/missing parameter";
                                }
                            }
                        }
                        else 
                        {
                            commandList[0] = "error";
                            commandList[1] = "invalid/missing parameter";
                        }
                    }

                    if (noInputCommands.Contains(commandList[0])) //no additional input command and parameter validation
                    {
                        if (commandList.Count == 1)
                        {
                        }
                        else
                        {
                            commandList[0] = "error";
                            commandList[1] = "unnecerssary parameter";
                        }
                    }

                    if (oneIntCommands.Contains(commandList[0]))//one integer command and parameter validation
                    {
                        if (commandList.Count == 2)
                        {
                            if (int.TryParse(commandList[1], out _))
                            {
                            }
                            else
                            {
                                commandList[0] = "error";
                                commandList[1] = "invalid/missing parameter";
                            }
                        }
                        else 
                        {
                            commandList[0] = "error";
                            commandList[1] = "invalid/missing parameter";
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
                                commandList[0] = "error";
                                commandList[1] = "invalid/missing parameter";
                            }
                        }

                        if (commandList[0] == "pen")
                        {
                            if (validColour.Contains(commandList[1]))
                            {
                            }
                            else
                            {
                                commandList[0] = "error";
                                commandList[1] = "invalid/missing parameter";
                            }
                        }
                    }
                }
            }

            return commandList;
        }

        public static List<string> multiLineProcess(System.Windows.Forms.TextBox userInput) //breaks down each line into a list element after validating
        {
            List<string> commandLines = new List<string> (); //stores singular lines of command after validation
   
            foreach (string line in userInput.Lines) 
            {
                List<string> lineCommandList = Parser.processSingleLine(line); //validates singular line

                string lineCommandString = string.Join(" ", lineCommandList);
                
                commandLines.Add(lineCommandString);
            }

            return commandLines;
        }
    }
}
