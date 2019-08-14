using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Base
{
    public abstract class NodeBase : INode
    {
        public List<NodeBase> Parents { get; set; }
        public bool? Output { get; set; }
        public string NodeId { get; set; }
        public bool FoundInfiniteLoop { get; set; }
        public void AddParent(NodeBase parent)
        {
            Parents.Add(parent);
        }

        public abstract void AddChild(NodeBase child);
        public abstract void AddStrategy(ICalculationStrategy strategy);
        public abstract void Calculate();
        public abstract void InfiniteLoop(NodeBase calledBy);
        public abstract void SetChildrenStates();

        public abstract void Accept(IVisitor visitor, NodeBase child);
    }
}
