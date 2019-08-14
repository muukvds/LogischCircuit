using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Utilities
{
    public class Parser
    {
        public Parser()
        {

        }

        public void Parse(IEnumerable<string> lines, out List<string[]> _nodes, out Dictionary<string, string[]> _connections)
        {
            lines = lines.Where(line => !line.StartsWith("#"));
            int separator = Array.IndexOf(lines.ToArray(), "");
            IEnumerable<string> nodes = lines.Take(separator);
            IEnumerable<string> connections = lines.Skip(separator + 1);

            _nodes = new List<string[]>();
            _connections = new Dictionary<string, string[]>();

            _nodes = new List<string[]>();

            foreach (string node in nodes)
            {

                var n = node.Split(':').Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

                n[1] = n[1].Replace(";", "");

                _nodes.Add(n);
            }

            _connections = new Dictionary<string, string[]>();

            foreach (string connection in connections)
            {
                var n = connection.Split(':').Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
                n[1] = n[1].Replace(";", "");

                var nextArray = n[1].Split(',');
                _connections[n[0]] = nextArray;
            }
        }
    }
}
