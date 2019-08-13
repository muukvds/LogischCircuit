using LogischCircuit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.State
{
    public abstract class BaseState
    {
        public Node node;

        public abstract void Calculate();
    }
}
