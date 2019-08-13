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
    class NOT : ICalculationStrategy
    {
        public bool Calculate(List<NodeTemplate> parents)
        {
            if (parents[0].Output.Value)
            {
                return false;
            }

            return true;
        }

        public static void RegisterStrategy()
        {
            CalculationStrategyFactory.GetInstance().AddNodeType<NOT>("NOT");
        }
    }
}
