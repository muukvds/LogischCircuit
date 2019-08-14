using LogischCircuit.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.State
{
    class ReadyState : BaseState
    {
        public ReadyState(BaseState state)
        {
            this.node = state.node;
        }

        public override void Calculate()
        {
            //If the node has parents, calcualte your output.
            if (node.Parents.Count > 0)
            {
                node.Output = node.CalculationStrategy.Calculate(node.Parents);
            }

            //tells all its children to calculate their out put
            node.Children.ForEach(c => c.Calculate());

            //set completestate so the node doesnt calculate more than once
            node.State = new CompleteState(this);
        }
    }
}
