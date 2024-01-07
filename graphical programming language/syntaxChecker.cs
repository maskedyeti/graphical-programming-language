using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical_programming_language
{
    public class syntaxChecker
    {
        bool endMethod = true;
        bool endIf = true;
        bool endWhile = true;
        


        public void CheckVariableDeclaration(List<string> commandList)
        {
            
            if (commandList.Count == 3 && commandList[1] == "=")
            {
                if (int.TryParse(commandList[0], out _))
                {
                    throw new InvalidVariableNameException($"invalid name of variable {commandList[0]}, varaibles can only be created with string or chr not integers");
                }
            }

            if (commandList.Count() == 3 && commandList[1] == "=")
            {
                if (int.TryParse(commandList[2], out _))
                {

                }
                else if (Parser.variables.ContainsKey(commandList[2]))
                {
                    
                }
                else
                {
                    throw new InvalidVariableValueDeclerationException($"Invalid value assignment to variable {commandList[0]}");
                }

            }
            else if (commandList.Count() == 5 && commandList[1] == "=" && Parser.operations.Contains(commandList[3]))
            {

                if (int.TryParse(commandList[2], out _) && int.TryParse(commandList[4], out _))
                {

                }
                else if (Parser.variables.ContainsKey(commandList[2]) && int.TryParse(commandList[4], out _))
                {

                }
                else if (Parser.variables.ContainsKey(commandList[4]) && int.TryParse(commandList[2], out _))
                {

                }
                else if (Parser.variables.ContainsKey(commandList[2]) && int.TryParse(commandList[4], out _))
                {

                }
                else if (Parser.variables.ContainsKey(commandList[2]) && Parser.variables.ContainsKey(commandList[4]))
                {

                }
                else
                {

                    throw new InvalidVariableValueDeclerationException($"Invalid value assignment to variable {commandList[0]}, ensure that only numbers and valid variables are used in equations.");

                }
            }
        }

        public void CheckMethodDecleration(List<string> multiLine)
        {
            bool endMethod = true;
            int lineNumber = 0;
            for (int i = 0; i < multiLine.Count; i++)
            {
                
                List<string> commandList = multiLine[i].Split(' ').ToList();
                if (commandList[0] == "method")
                {
                    if (commandList.Count() == 3)
                    {
                        lineNumber = (i + 1);
                        endMethod = false;
                    }
                    else
                    {
                        throw new InvalidMethodDeclerationException($"error with {commandList[0]} line {(i + 1).ToString()}, defineing a method requires the 'method' keyword followed by the method name followed by '()'");
                    }
                }else if (commandList[0] == "endmethod")
                {
                    endMethod = true;
                }
            }

            if (!endMethod) 
            {
                throw new NoEndMethodException($"error line {lineNumber.ToString()},methods require and 'endmethod' keyword at the end of their function");
            }
        }

        public void CheckIfDecleration(List<string> multiLine)
        {
            bool endIf = true;
            int lineNumber = 0;
            for (int i = 0; i < multiLine.Count; i++)
            {
                List<string> commandList = multiLine[i].Split(' ').ToList();
                if (commandList[0] == "if")
                {
                    if (commandList[2] == "=" || commandList[2] == ">" || commandList[2] == "<")
                    {
                        if (int.TryParse(commandList[1], out _) || Parser.variables.ContainsKey(commandList[1]))
                        {
                            endIf = false;
                            lineNumber = (i + 1);
                        }
                        else
                        {
                            throw new IfInvalidOperatorException($"{commandList[1]}, line {(i + 1).ToString()}, is invalid as a parameter for this if sttament");
                        }

                        if (int.TryParse(commandList[3], out _) || Parser.variables.ContainsKey(commandList[3]))
                        {
                            endIf = false;
                            lineNumber = (i + 1);
                        }
                        else
                        {
                            throw new IfInvalidOperatorException($"{commandList[3]}, line {(i + 1).ToString()} is invalid as a parameter for this if sttament");
                        }
                    }
                    else
                    {
                        throw new IfInvalidOperatorException($"{commandList[2]}, line {(i + 1).ToString()}, is an invalid operator, please use '=,<,>'");
                    }

                }else if (commandList[0] == "endif")
                {
                    endIf = true;
                }
            }

            if (!endIf)
            {
                throw new NoEndIfException($"line {lineNumber.ToString()},if statments require an endif statment");
            }
        }

        public void CheckWhileDecleration(List<string> multiLine)
        {
            bool endWhile = true;
            int lineNumber = 0;

            for (int i = 0; i < multiLine.Count; i++)
            {
                List<string> commandList = multiLine[i].Split(' ').ToList();
                if (commandList[0] == "while")
                {
                    if (commandList[2] == "=" || commandList[2] == ">" || commandList[2] == "<")
                    {
                        if (int.TryParse(commandList[1], out _) || Parser.variables.ContainsKey(commandList[1]))
                        {
                            endWhile = false;
                            lineNumber = (i + 1);
                        }
                        else
                        {
                            throw new WhileInvalidOperatorException($"{commandList[1]}, line {i.ToString()}, is invalid as a parameter for this if sttament");
                        }

                        if (int.TryParse(commandList[3], out _) || Parser.variables.ContainsKey(commandList[3]))
                        {
                            endWhile = false;
                            lineNumber = (i + 1);
                        }
                        else
                        {
                            throw new WhileInvalidOperatorException($"{commandList[3]}, line {(i+1).ToString()}, is invalid as a parameter for this if sttament");
                        }
                    }
                    else
                    {
                        throw new WhileInvalidOperatorException($"{commandList[2]}, line {(i + 1).ToString()}, is an invalid operator, please use '=,<,>'");
                    }

                }else if (commandList[0] == "endloop")
                {
                    MessageBox.Show("helllp");
                    endWhile = true;
                }
            }

            if (!endWhile)
            {
                throw new NoEndWhileException($"line {lineNumber.ToString()}, while statments require an endloop statment");
            }
        }

        public class InvalidVariableValueDeclerationException : Exception
        {
            public InvalidVariableValueDeclerationException(string message) : base(message) { }
        }

        public class InvalidVariableNameException : Exception
        {
            public InvalidVariableNameException(string message) : base(message) { }
        }

        public class InvalidMethodDeclerationException : Exception 
        { 
            public InvalidMethodDeclerationException(string message) : base(message) { }
        }

        public class NoEndMethodException : Exception
        {
            public NoEndMethodException(string message) : base(message) { }
        }

        public class IfInvalidOperatorException : Exception
        {
            public IfInvalidOperatorException(string message) : base(message) { }
        }

        public class IfInvalidOperandException : Exception
        {
            public IfInvalidOperandException(string message) : base(message) { }

        }

        public class NoEndIfException : Exception 
        {
            public NoEndIfException(string message) : base(message) { }
        }

        public class WhileInvalidOperatorException : Exception
        {
            public WhileInvalidOperatorException(string message) : base(message) { }
        }

        public class WhileInvalidOperandException : Exception
        {
            public WhileInvalidOperandException(string message) : base(message) { }

        }

        public class NoEndWhileException : Exception
        {
            public NoEndWhileException(string message) : base(message) { }
        }




    }
}

