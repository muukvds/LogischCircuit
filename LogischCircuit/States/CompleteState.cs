using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.State
{
    class CompleteState : BaseState
    {
        public CompleteState(BaseState state)
        {
            this.node = state.node;
        }

        public override void Calculate()
        {

        }
    }
}
