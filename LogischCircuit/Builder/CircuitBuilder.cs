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
    //builds the circuit, creates node builders to create the nodes to add to the circuit after reading the file from the filepath
    
    class CircuitBuilder
    {
        private IBoard _circuit;
        private List<string[]> _nodes;
        private Dictionary<string, string[]> _connections;

        public CircuitBuilder()
        {
            _circuit = new Circuit();
        }

        // reads the file from the path and created the _connections dictonairy
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

        //calles the ReadFile method and 
        public void Create(string filepath)
        {
            ReadFile(filepath);
            BuildNodes(out Dictionary<string, NodeTemplate> nodeList);
            ConnectNodes(nodeList);
        }

        private void ConnectNodes(Dictionary<string, NodeTemplate> nodeList)
        {
            // connects the notes to eatch other, and checkes if the connections are correct
            foreach (KeyValuePair<string, NodeTemplate> entry in nodeList)
            {
                // add node to other node as a chiled if nodeId exists in connections
                if (_connections.ContainsKey(entry.Key))
                {
                    foreach (string conn in _connections[entry.Key])
                    {
                        entry.Value.AddChild(nodeList[conn]);
                    }
                }

                //todo iets met de loop
                // checkes if nodes are connected to an other node.
                // if a loop acours the circuit will still be build but the calculate will just stop.
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
                }
            }
        }

        private void BuildNodes(out Dictionary<string, NodeTemplate> nodeList)
        {
            //dictonairy of nodeId and node
            nodeList = new Dictionary<string, NodeTemplate>();

            // builds nodes and adds them to the circuit
            foreach (string[] node in _nodes)
            {
                NodeBuilder builder;

                if (node[1].StartsWith("INPUT"))
                {
                    builder = new NodeBuilder();

                    if (node[1].EndsWith("HIGH"))
                    {
                        builder.SetOutput(true);
                    }
                    else
                    {
                        builder.SetOutput(false);
                    }

                    builder.SetId(node[0]);
                    NodeTemplate inputNode = builder.Build();
                    nodeList[node[0]] = inputNode;
                    _circuit.Inputs.Add(inputNode);
                }
                else if (node[1] == "PROBE")
                {
                    builder = new NodeBuilder("PROBE");
                    builder.SetId(node[0]);
                    NodeTemplate probeNode = builder.Build();
                    nodeList[node[0]] = probeNode;
                    _circuit.Probes.Add(probeNode);

                }
                else
                {
                    builder = new NodeBuilder();
                    builder.SetId(node[0]);
                    builder.AddStrategy(node[1]);
                    NodeTemplate newNode = builder.Build();
                    nodeList[node[0]] = newNode;
                    _circuit.Nodes.Add(newNode);
                }
            }
        }

        public IBoard Build()
        {
            return _circuit;
        }

    }
}
