using LogischCircuit.Base;
using LogischCircuit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Interface
{
    public interface IVisitor
    {
        void VisitNode(Node node, NodeBase child);

        void VisitProbe(Probe probe, NodeBase child);
    }
}
