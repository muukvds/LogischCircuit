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
        NodeTemplate _node;

        public NodeBuilder(string name)
        {
            _node = new Probe();
        }

        public NodeBuilder()
        {
            _node = new Node();
        }

        //todo add type for view
        public void AddStrategy(string strategyName)
        {
            ICalculationStrategy strategy;

            switch (strategyName)
            {
                case "XOR":
                    strategy = CalculationStrategyFactory.GetInstance().CreateStrategy("AND");
                    strategy = CalculationStrategyDecoratorFactory.GetInstance().CreateStrategy(strategy, "ORDecorator");
                    _node.AddStrategy(strategy);
                    break;
                case "NAND":
                    strategy = CalculationStrategyFactory.GetInstance().CreateStrategy("NOT");
                    strategy = CalculationStrategyDecoratorFactory.GetInstance().CreateStrategy(strategy, "ANDDecorator");
                    _node.AddStrategy(strategy);
                    break;
                case "NOR":
                    strategy = CalculationStrategyFactory.GetInstance().CreateStrategy("NOT");
                    strategy = CalculationStrategyDecoratorFactory.GetInstance().CreateStrategy(strategy, "ORDecorator");
                    _node.AddStrategy(strategy);
                    break;
                default:
                    strategy = CalculationStrategyFactory.GetInstance().CreateStrategy(strategyName);
                    _node.AddStrategy(strategy);
                    break;
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

        public NodeTemplate Build()
        {
            return _node;
        }
    }
}
