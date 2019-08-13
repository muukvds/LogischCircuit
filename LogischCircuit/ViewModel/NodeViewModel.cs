using LogischCircuit.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.ViewModel
{
    public class NodeViewModel
    {
        private NodeTemplate _node;
        public NodeViewModel(NodeTemplate node)
        {
            _node = node;
        }

        public string Id { get { return _node.NodeId; } }

        

    }
}
