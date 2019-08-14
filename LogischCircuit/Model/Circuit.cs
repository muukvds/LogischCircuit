using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;

namespace LogischCircuit.Model
{
    class Circuit
    {

        public List<NodeBase> Inputs { get; set; }
        public List<NodeBase> Nodes { get; set; }
        public List<NodeBase> Outputs { get; set; }


        public Circuit()
        {
            Inputs = new List<NodeBase>();
            Nodes = new List<NodeBase>();
            Outputs = new List<NodeBase>();
        }

        public void Calculate()
        {
            foreach (NodeBase input in Inputs)
            {
                input.Calculate();
            }
        }

        public void SetStates()
        {
            foreach (Node node in Inputs)
            {
                node.SetChildrenStates();
            }
        }


    }
}
