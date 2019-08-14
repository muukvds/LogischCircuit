using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using LogischCircuit.Utilities;

namespace LogischCircuit.Builder
{
    //builds the circuit, creates node builders to create the nodes to add to the circuit after reading the file from the filepath
    
    class CircuitBuilder
    {

        private Circuit _circuit;
        private List<string[]> _nodes;
        private Dictionary<string, string[]> _connections;

        public string ErrorMessage { get; private set; }

        public CircuitBuilder()
        {
            _circuit = new Circuit();
        }

        private void ReadFile(string path)
        {
            TextFileReader tr = new TextFileReader();
            var lines = tr.Parse(path);
            Parser parser = new Parser();
            parser.Parse(lines, out _nodes, out _connections);
        }

        public bool Create(string filepath)
        {
            //read textfile
            ReadFile(filepath);
            var correctCircuit = true;

            //create nodes
            Dictionary<string, NodeBase> nodeList = new Dictionary<string, NodeBase>();

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
                    NodeBase inputNode = builder.Build();
                    nodeList[node[0]] = inputNode;
                    _circuit.Inputs.Add(inputNode);
                }

                else if (node[1] == "PROBE")
                {
                    builder = new NodeBuilder("PROBE");
                    builder.SetId(node[0]);
                    NodeBase outputNode = builder.Build();
                    nodeList[node[0]] = outputNode;
                    _circuit.Outputs.Add(outputNode);

                }

                else
                {
                    builder = new NodeBuilder();
                    builder.SetId(node[0]);
                    builder.AddStrategy(node[1]);
                    NodeBase newNode = builder.Build();
                    nodeList[node[0]] = newNode;
                    _circuit.Nodes.Add(newNode);
                }
            }

            //add connections to the nodes
            foreach (KeyValuePair<string, NodeBase> entry in nodeList)
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
                    //check whether there is an unconnected node
                    if (entry.Value.Output.HasValue)
                    {
                        ErrorMessage = "Warning: input " + entry.Key + " Is nergens aan verbonden!";
                        Console.WriteLine("Warning: input " + entry.Key + " Is nergens aan verbonden!");
                    }
                    else
                    {
                        ErrorMessage = "De Node " + entry.Key + " heeft geen connecties, Kies een ander circuit.";
                        Console.WriteLine("De Node " + entry.Key + " heeft geen connecties, Kies een ander circuit.");
                        correctCircuit = false;
                    }

                }

            }

            //check whther the circuit contains an infinite loop
            _circuit.Inputs.ForEach(inp => inp.InfiniteLoop(null));
            if (nodeList.ToList().Any(n => n.Value.FoundInfiniteLoop))
            {
                ErrorMessage = "Dit circuit heeft een infinite loop, kies een ander circuit.";
                Console.WriteLine("Dit circuit heeft een infinite loop, kies een ander circuit.");

                correctCircuit = false;
            }
            return correctCircuit;

        }

        public Circuit Build()
        {
            return _circuit;
        }

    }
}
