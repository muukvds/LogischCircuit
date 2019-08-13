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
    class ANDDecorator : ICalculationStrategy
    { 
    
        private ICalculationStrategy _baseStrategy;
        private ICalculationStrategy _strategy;

        public ANDDecorator(ICalculationStrategy strategy) : base()
        {
            _baseStrategy = new AND();
            _strategy = strategy;
        }

        public bool Calculate(List<NodeTemplate> parents)
        {
            if (_baseStrategy.Calculate(parents) && _strategy.Calculate(parents))
            {
                return true;
            }

            else if (_baseStrategy.Calculate(parents) || _strategy.Calculate(parents))
            {
                return true;
            }

            return false;
        }

        public static void RegisterStrategy()
        {
            CalculationStrategyDecoratorFactory.GetInstance().AddNodeType<ANDDecorator>("ANDDecorator");
        }
    }
}
