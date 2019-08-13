using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;

namespace LogischCircuit.Interface
{
    public interface IBoard
    {
        List<NodeTemplate> Inputs { get; set; }
        List<NodeTemplate> Nodes { get; set; }
        List<NodeTemplate> Probes { get; set; }

        void Calculate();
    }
}
