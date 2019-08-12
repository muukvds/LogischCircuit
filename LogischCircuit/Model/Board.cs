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
        public List<BaseNode> Inputs { get; set; }

        public Board()
        {
            Children = new List<IBoard>();
            Inputs = new List<BaseNode>();
        }

        public void AddChild(IBoard child)
        {
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
