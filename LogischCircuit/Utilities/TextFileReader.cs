using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Utilities
{
    public class TextFileReader
    {

        public IEnumerable<string> Parse(string path)
        {
            IEnumerable<string> lines = File.ReadAllLines(path).ToList();

            return lines;

        }
    }
}
