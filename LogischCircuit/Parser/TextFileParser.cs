using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Parser
{
    public class TextFileParser
    {
        public void Parse(string path, out IEnumerable<string> nodes, out IEnumerable<string> connections)
        {
            IEnumerable<string> lines = File.ReadAllLines(path).ToList();

            //remove comments
            lines = lines.Where(line => !line.StartsWith("#"));
            int separator = Array.IndexOf(lines.ToArray(), "");
            nodes = lines.Take(separator);
            connections = lines.Skip(separator + 1);

        }
    }
}
