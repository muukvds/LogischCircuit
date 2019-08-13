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
            if (node.Parents.Count > 0)
            {
                node.Output = node.CalculationStrategy.Calculate(node.Parents);
            }

            node.Children.ForEach(c => c.Calculate());
            node.State = new CompleteState(this);
        }
    }
}
