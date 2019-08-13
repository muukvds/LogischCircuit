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
        private ICalculationStrategy _strategy;

        public NOTDecorator(ICalculationStrategy strategy) : base()
        {
            _baseStrategy = new NOT();
            _strategy = strategy;
        }

        public bool Calculate(List<NodeTemplate> parents)
        {
            if (_baseStrategy.Calculate(parents) != _strategy.Calculate(parents))
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
