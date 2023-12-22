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
}
