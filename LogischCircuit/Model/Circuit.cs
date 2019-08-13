using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;

namespace LogischCircuit.Model
{
    class Circuit : IBoard
    {
        private int _amountOfProbes;

        public List<NodeTemplate> Inputs { get; set; }
        public List<NodeTemplate> Nodes { get; set; }
        public List<NodeTemplate> Probes { get; set; }

        //todo make a list of components and outpuds (probes) to ba able to show in the view 

        public int AmountOfProbes { get; set; }

        public Circuit()
        {
            Inputs = new List<NodeTemplate>();
            Nodes = new List<NodeTemplate>();
            Probes = new List<NodeTemplate>();
            _amountOfProbes = 0;
        }

        public void Calculate()
        {
            foreach (NodeTemplate input in Inputs)
            {
                input.Calculate();
            }
        }
    }
}
