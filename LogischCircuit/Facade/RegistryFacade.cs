using LogischCircuit.Decorator;
using LogischCircuit.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Facade
{
    static class RegistryFacade
    {
        // filles the options (dictonairy) of there respective factories.
        // calles all diferent options to register themselves at there factories
        public static void RegisterStrategies()
        {
            AND.RegisterStrategy();
            OR.RegisterStrategy();
            NOT.RegisterStrategy();
            ANDDecorator.RegisterStrategy();
            NOTDecorator.RegisterStrategy();
            ORDecorator.RegisterStrategy();
        }
    }
}
