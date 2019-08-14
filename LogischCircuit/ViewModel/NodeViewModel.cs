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
        private NodeBase _node;
        private MainViewModel _vm;

        public NodeViewModel(NodeBase node, MainViewModel vm)
        {
            _node = node;
            _vm = vm;
        }

        public string Id { get { return _node.NodeId; } }

        

    }
}
