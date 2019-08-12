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
        List<BaseNode> Inputs { get; set; }

        void Calculate();
    }
}
