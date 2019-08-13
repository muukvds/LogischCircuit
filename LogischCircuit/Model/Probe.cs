using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;

namespace LogischCircuit.Model
{
    class Probe : NodeTemplate
    {

        public Probe()
        {
            Parents = new List<NodeTemplate>();
        }

        public override void AddChild(NodeTemplate child)
        {
            child.AddParent(this);
        }

        public override void Calculate()
        {
            Output = Parents[0].Output;

        }

        public override void AddStrategy(ICalculationStrategy strategy)
        {

        }



    }
}
