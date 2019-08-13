using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Interface;

namespace LogischCircuit.Model
{
    class Board : IBoard
    {
        public List<IBoard> Children { get; private set; }
        public List<NodeTemplate> Inputs { get; set; }
        public List<NodeTemplate> Nodes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<NodeTemplate> Probes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Board()
        {
            Children = new List<IBoard>();
            Inputs = new List<NodeTemplate>();
        }

        public void AddChild(IBoard child)
        {
            Children.Clear();
            Children.Add(child);
        }

        public void Calculate()
        {
            foreach (IBoard child in Children)
            {
                child.Calculate();
            }
        }
    }
}
