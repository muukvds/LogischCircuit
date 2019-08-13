﻿using LogischCircuit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.State
{
    class UnreadyState : BaseState
    {
        public UnreadyState(Node node)
        {
            this.node = node;
        }

        public override void Calculate()
        {
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (node.Parents.TrueForAll(p => p.Output.HasValue))
            {
                node.State = new ReadyState(this);
                node.State.Calculate();
            }
        }
    }
}