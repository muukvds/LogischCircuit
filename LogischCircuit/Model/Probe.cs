using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.Visitor;

namespace LogischCircuit.Model
{
    public class Probe : NodeBase
    {
        private IVisitor _visitor;

        public Probe()
        {
            Parents = new List<NodeBase>();
            _visitor = new NodeVisitor();
        }

        public override void AddChild(NodeBase child)
        {
            Accept(_visitor, child);
        }

        public override void Calculate()
        {
            Output = Parents[0].Output;
        }

        public override void AddStrategy(ICalculationStrategy strategy)
        {

        }

        public override void InfiniteLoop(NodeBase calledBy)
        {

        }

        public override void SetChildrenStates()
        {
            Output = null;
        }

        //accept visitor method
        public override void Accept(IVisitor visitor, NodeBase child)
        {
            visitor.VisitProbe(this, child);
        }
    }
}
