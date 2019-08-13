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
    class ORDecorator : ICalculationStrategy
    {
        private ICalculationStrategy _baseStrategy;
        private ICalculationStrategy _strategy;

        public ORDecorator(ICalculationStrategy strategy) : base()
        {
            _baseStrategy = new OR();
            _strategy = strategy;
        }

        public bool Calculate(List<NodeTemplate> parents)
        {
            if (_baseStrategy.Calculate(parents) || _strategy.Calculate(parents))
            {
                return true;
            }

            return false;
        }

        public static void RegisterStrategy()
        {
            CalculationStrategyDecoratorFactory.GetInstance().AddNodeType<ORDecorator>("ORDecorator");
        }
    }
}
