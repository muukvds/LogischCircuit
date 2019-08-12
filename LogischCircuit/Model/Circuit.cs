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

        // public bool? Output { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<BaseNode> Inputs { get; set; }

        public int AmountOfProbes { get; set; }

        public Circuit()
        {
            Inputs = new List<BaseNode>();
            _amountOfProbes = 0;
        }

        public void Calculate()
        {
            foreach (BaseNode input in Inputs)
            {
                input.Calculate();
            }
        }
    }
}
