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

namespace graphical_programming_language
{
    public class Parser //handles input processing and input validation
    {
        static List<string> validCommands = new List<string> { "moveto", "drawto", "clear", "reset", "rectangle"
                                                        , "circle", "triangle", "pen", "fill"};

        //contains commands and their requiredparameters for input validation
        static List<string> twoIntCommands = new List<string> {"moveto", "drawto", "rectangle", "triangle"}; 
        static List<string> noInputCommands = new List<string> {"pen", "clear", "reset"};
        static List<string> oneIntCommands = new List<string> { "circle" };
        static List<string> stringCommands = new List<string> { "pen", "fill"};

        public static List<string> processSingleLine(String command)//method to split inputted line of command into a list and validate it
        {
            List<string> commandList = new List<string> {};

            bool commandEmpty = string.IsNullOrWhiteSpace(command);//checks if the their is a command present

            if (commandEmpty == true) 
            {
                commandList[0] = "error";
                commandList[1] = "please enter a command";

            }

            else if (commandEmpty == false)
            {

                commandList = command.Split(' ').ToList();
 
                if (validCommands.Contains(commandList[0]) == true) 
                { 
                    if (twoIntCommands.Contains(commandList[0]) == true)
                    {
                        if (int.TryParse(commandList[1], out _)   == true)
                        {
                            if (int.TryParse(commandList[2], out _) == true) 

                            {
                            }
                            else
                            {
                                commandList[0] = "error";
                                commandList[1] = "please enter 2 integers";
                            }
                        }
                    }
                    if (noInputCommands.Contains(commandList[0]) == true)
                    {
                        if (commandList.Count == 1)
                        {
                        }
                        else
                        {
                            commandList[0] = "error";
                            commandList[1] = "no additional entry required";
                        }
                    }
                    if (oneIntCommands.Contains(commandList[0]))
                    {
                        if (int.TryParse(commandList[1], out _))
                        {
                        }
                        else if (commandList.Count == 2)
                        {
                        }
                        else 
                        {
                            commandList[0] = "error";
                            commandList[1] = "please enter one additional number";
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
                                commandList[1] = "please select on or off";
                            }
                        }

                        if (commandList[0] == "pen")// come back to 
                        {
                            
                        }
                    }
                }
            }

            return commandList;
        }
    }
}
