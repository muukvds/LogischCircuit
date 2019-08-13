using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Factory
{
    class CalculationStrategyDecoratorFactory
    {

        public Dictionary<string, Type> _strategies;
        private static CalculationStrategyDecoratorFactory _instance = null;

        public CalculationStrategyDecoratorFactory()
        {
            _instance = this;
            _strategies = new Dictionary<string, Type>();
        }

        public ICalculationStrategy CreateStrategy(ICalculationStrategy strategy, string name)
        {
            // use activator to dinamicly create classes withouth hardcoding what class you need to create. this prevents a switch
            return (ICalculationStrategy)Activator.CreateInstance(_strategies[name], strategy);
        }

        public void AddNodeType<T>(string type)
        {
            _strategies.Add(type, typeof(T));
        }

        public static CalculationStrategyDecoratorFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CalculationStrategyDecoratorFactory();
            }

            return _instance;
        }

    }
}
