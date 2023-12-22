using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphical_programming_language
{
    public interface IVariable
    {
        string Name { get; }
        int Value { get; set; }

    }
    public class UserVariable : IVariable
    {
        public string Name { get; private set; }
        public int Value { get; set; }

        public UserVariable(string name, int value)
        {
            Name = name;
            Value = value;
        }


    }
}
