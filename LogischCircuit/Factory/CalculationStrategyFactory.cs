using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Factory
{
    class CalculationStrategyFactory
    {
        private Dictionary<string, Type> _strategies;
        private static CalculationStrategyFactory _instance = null;

        public CalculationStrategyFactory()
        {
            _instance = this;
            _strategies = new Dictionary<string, Type>();
        }

        public ICalculationStrategy CreateStrategy(string strategy)
        {
            return (ICalculationStrategy)Activator.CreateInstance(_strategies[strategy]);
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
        public static CalculationStrategyFactory GetInstance()
        {

            if (_instance == null)
            {
                _instance = new CalculationStrategyFactory();
            }

            return _instance;
        }


    }
}
