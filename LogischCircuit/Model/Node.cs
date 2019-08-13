using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.State;

namespace LogischCircuit.Model
{
    public class Node : NodeTemplate
    {
        public List<NodeTemplate> Children { get; private set; }
        public ICalculationStrategy CalculationStrategy { get; private set; }
        public BaseState State { get; set; }
        
        public Node()
        {
            Parents = new List<NodeTemplate>();
            Children = new List<NodeTemplate>();
            State = new UnreadyState(this);
        }

        public Node(ICalculationStrategy strategy)
        {
            CalculationStrategy = strategy;
            Parents = new List<NodeTemplate>();
            Children = new List<NodeTemplate>();
            State = new UnreadyState(this);
        }

        public override void AddStrategy(ICalculationStrategy strategy)
        {
            CalculationStrategy = strategy;
        }

        public override void AddChild(NodeTemplate child)
        {
            child.AddParent(this);
            Children.Add(child);
        }

        public override void Calculate()
        {
            //let state calculate to prevent a switch that will check the type of state
            State.Calculate();

        }
    }
}
