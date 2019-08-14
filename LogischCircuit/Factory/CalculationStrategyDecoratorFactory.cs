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

        private Dictionary<string, Type> _strategies;
        private static CalculationStrategyDecoratorFactory _instance = null;

        public CalculationStrategyDecoratorFactory()
        {
            _instance = this;
            _strategies = new Dictionary<string, Type>();
        }

        public ICalculationStrategy CreateStrategy(ICalculationStrategy strategy, string name)
        {
            return (ICalculationStrategy)Activator.CreateInstance(_strategies[name], strategy);
        }

        public void AddNodeType<T>(string type)
        {
            _strategies.Add(type, typeof(T));
        }

        public void ResetDictionary()
        {
            _strategies = new Dictionary<string, Type>();
        }

        //gets singleton instance
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
