using LogischCircuit.Base;
using LogischCircuit.Factory;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Builder
{
    //builds the nodes using the CalculationStrategyFactory for basic stratagys and the CalculationStrategyDecoratorFactory for special stratagies like the NAND. 
    // uses decorator pattern and factory
    class NodeBuilder
    {
        NodeBase _node;

        public NodeBuilder(string name)
        {
            _node = new Probe();
        }

        public NodeBuilder()
        {
            _node = new Node();
        }

        public void AddStrategy(string strategyName)
        {
            ICalculationStrategy strategy;

            if (strategyName == "NAND")
            {
                strategy = CalculationStrategyFactory.GetInstance().CreateStrategy("AND");
                strategy = CalculationStrategyDecoratorFactory.GetInstance().CreateStrategy(strategy, "NOTDecorator");
                _node.AddStrategy(strategy);
            }

            else if (strategyName == "NOR")
            {
                strategy = CalculationStrategyFactory.GetInstance().CreateStrategy("OR");
                strategy = CalculationStrategyDecoratorFactory.GetInstance().CreateStrategy(strategy, "NOTDecorator");
                _node.AddStrategy(strategy);
            }

            else
            {
                strategy = CalculationStrategyFactory.GetInstance().CreateStrategy(strategyName);
                _node.AddStrategy(strategy);
            }
        }

        public void SetId(string id)
        {
            _node.NodeId = id;
        }

        public void SetOutput(bool output)
        {
            _node.Output = output;
        }

        public NodeBase Build()
        {
            return _node;
        }
    }
}
