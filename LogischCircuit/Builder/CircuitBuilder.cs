using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using LogischCircuit.Parser;

namespace LogischCircuit.Builder
{
    class CircuitBuilder
    {
        private IBoard _circuit;
        private List<string[]> _nodes;
        private Dictionary<string, string[]> _connections;

        public CircuitBuilder()
        {
            _circuit = new Circuit();
        }

        private void ReadFile(string path)
        {
            TextFileParser tp = new TextFileParser();
            tp.Parse(path, out IEnumerable<string> nodes, out IEnumerable<string> connections);

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

        public void Create(string filepath)
        {
            //VRAAG readfile in Create emethod??? mag dat?
            ReadFile(filepath);
            //VRAAG: moeten we een private field met nodefactory maken of elke keer opnieuwe ophalen in de for loop?

            Dictionary<string, BaseNode> nodeList = new Dictionary<string, BaseNode>();

            foreach (string[] node in _nodes)
            {

               // NodeBuilder builder;

                if (node[1].StartsWith("INPUT"))
                {
                   // builder = new NodeBuilder();

                    if (node[1].EndsWith("HIGH"))
                    {
                       // builder.SetOutput(true);
                    }
                    else
                    {
                       // builder.SetOutput(false);
                    }

                   // builder.SetId(node[0]);
                   // BaseNode inputNode = builder.Build();
                    //nodeList[node[0]] = inputNode;
                   // _circuit.Inputs.Add(inputNode);
                }

                else if (node[1] == "PROBE")
                {
                   // builder = new NodeBuilder("PROBE");
                   // builder.SetId(node[0]);
                   // nodeList[node[0]] = builder.Build();

                }

                else
                {
                   // builder = new NodeBuilder();
                  //  builder.SetId(node[0]);
                   // builder.AddStrategy(node[1]);
                  //  nodeList[node[0]] = builder.Build();
                }
            }

            foreach (KeyValuePair<string, BaseNode> entry in nodeList)
            {
                if (_connections.ContainsKey(entry.Key))
                {
                    foreach (string conn in _connections[entry.Key])
                    {
                        entry.Value.AddChild(nodeList[conn]);
                    }
                }
                else if (!(entry.Value is Probe))
                {
                    if (entry.Value.Output.HasValue)
                    {
                        Console.WriteLine("Warning: input " + entry.Key + " Is nergens aan verbonden!");
                    }
                    else
                    {
                        Console.WriteLine("Unconnected!!!!!!!!!");
                    }
                    //VRAAG: circuit 3 heeft een input zonder connecties maar is wel goed??

                }

            }

        }

        public IBoard Build()
        {
            return _circuit;
        }

    }
}
