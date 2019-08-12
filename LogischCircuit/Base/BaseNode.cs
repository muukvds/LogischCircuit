using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Base
{
    public abstract class BaseNode
    {
        public List<BaseNode> Parents { get; set; }
        public bool? Output { get; set; }
        public string NodeId { get; set; }

        public void AddParent(BaseNode parent)
        {
            Parents.Add(parent);
        }

        public abstract void AddChild(BaseNode child);
        public abstract void AddStrategy(ICalculationStrategy strategy);
        public abstract void Calculate();
    }
}
