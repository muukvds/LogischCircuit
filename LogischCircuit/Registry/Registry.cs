using LogischCircuit.Decorator;
using LogischCircuit.Factory;
using LogischCircuit.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Registries
{
    static public class Registry
    {
        // filles the options (dictonairy) of there respective factories.
        // calles all diferent options to register themselves at there factories
        public static void RegisterStrategies()
        {
            CalculationStrategyFactory.GetInstance().ResetDictionary();
            CalculationStrategyDecoratorFactory.GetInstance().ResetDictionary();
            AND.RegisterStrategy();
            OR.RegisterStrategy();
            NOT.RegisterStrategy();
            NOTDecorator.RegisterStrategy();
        }
    }
}
