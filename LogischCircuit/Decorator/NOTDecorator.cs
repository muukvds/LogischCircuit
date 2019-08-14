using LogischCircuit.Base;
using LogischCircuit.Factory;
using LogischCircuit.Interface;
using LogischCircuit.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Decorator
{
    class NOTDecorator : ICalculationStrategy
    {
        private ICalculationStrategy _baseStrategy;

        public NOTDecorator(ICalculationStrategy strategy) : base()
        {
            _baseStrategy = strategy;
        }

        public bool Calculate(List<NodeBase> parents)
        {
            //returns the opposite of its base strategy
            if (!_baseStrategy.Calculate(parents))
            {
                return true;
            }
            return false;
        }

        public static void RegisterStrategy()
        {
            CalculationStrategyDecoratorFactory.GetInstance().AddNodeType<NOTDecorator>("NOTDecorator");
        }
    }
}
