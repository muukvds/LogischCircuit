using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.State;
using LogischCircuit.Visitor;

namespace LogischCircuit.Model
{
    public class Node : NodeBase
    {
        public List<NodeBase> Children { get; private set; }
        public BaseState State { get; set; }
        public ICalculationStrategy CalculationStrategy { get; private set; }
        private List<NodeBase> _calledBy;
        private IVisitor _visitor;

        //constructor for input nodes
        public Node()
        {
            Parents = new List<NodeBase>();
            Children = new List<NodeBase>();
            State = new UnreadyState(this);
            _calledBy = new List<NodeBase>();
            _visitor = new NodeVisitor();
        }

        //constructor for logic nodes
        public Node(ICalculationStrategy strategy)
        {
            CalculationStrategy = strategy;
            Parents = new List<NodeBase>();
            Children = new List<NodeBase>();
            State = new UnreadyState(this);
            _visitor = new NodeVisitor();
        }

        public override void AddStrategy(ICalculationStrategy strategy)
        {
            CalculationStrategy = strategy;
        }

        public override void AddChild(NodeBase child)
        {
            Accept(_visitor, child);
        }

        public override void Calculate()
        {
            State.Calculate();
        }

        public override void SetChildrenStates()
        {
            State = new UnreadyState(this);
            if (Parents.Count > 0)
            {
                Output = null;
            }
            foreach (NodeBase node in Children)
            {
                node.SetChildrenStates();
            }
        }

        //check for infinite loop
        public override void InfiniteLoop(NodeBase calledBy)
        {
            if (calledBy != null)
            {
                if (_calledBy.Where(c => c == calledBy).Count() > 5)
                {
                    FoundInfiniteLoop = true;
                }
                else
                {
                    _calledBy.Add(calledBy);
                    Children.ForEach(c => c.InfiniteLoop(this));
                }
            }
            else
            {
                Children.ForEach(c => c.InfiniteLoop(this));
            }
        }

        //accept visitor method
        public override void Accept(IVisitor visitor, NodeBase child)
        {
            visitor.VisitNode(this, child);
        }
    }
}
