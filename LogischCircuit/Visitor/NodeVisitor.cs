using LogischCircuit.Base;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Visitor
{
    class NodeVisitor : IVisitor
    {
        public void VisitNode(Node node, NodeBase child)
        {
            child.AddParent(node);
            node.Children.Add(child);
        }

        public void VisitProbe(Probe probe, NodeBase child)
        {
            child.AddParent(probe);
        }
    }
}
