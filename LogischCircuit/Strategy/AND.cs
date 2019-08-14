using LogischCircuit.Base;
using LogischCircuit.Factory;
using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Strategy
{
    class AND : ICalculationStrategy
    {

        public bool Calculate(List<NodeBase> parents)
        {
            if (parents.TrueForAll(p => p.Output.Value))
            {
                return true;
            }

            return false;
        }

        public static void RegisterStrategy()
        {
            CalculationStrategyFactory.GetInstance().AddNodeType<AND>("AND");
        }
    }
}
