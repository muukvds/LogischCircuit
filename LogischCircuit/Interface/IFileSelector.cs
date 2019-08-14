using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Interface
{
    interface IFileSelector
    {
        string GetPathFromFile(string name);

        IEnumerable<string> getNames();

    }
}
