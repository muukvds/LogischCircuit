using LogischCircuit.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Interface
{
    public interface INode
    {
        void Accept(IVisitor visitor, NodeBase child);
    }
}
