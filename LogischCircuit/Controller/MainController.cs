﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Builder;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using LogischCircuit.Facade;

namespace LogischCircuit.Controller
{
    class MainController
    {
        private Board _board;
        public MainController()
        {
            RegistryFacade.RegisterStrategies();
            _board = new Board();
        }

        public void CreateBoard()
        {
            Board newBoard = new Board();
            _board.AddChild(newBoard);
            _board = newBoard;
        }

        public void BuildCircuit(string filepath)
        {
            CircuitBuilder cb = new CircuitBuilder();
            cb.Create(filepath);
            IBoard circuit = cb.Build();
            _board.AddChild(circuit);

        }

        public void Run()
        {
            _board.Calculate();
        }

        //needs a loop to return all circuis
        public List<NodeTemplate> getInputs()
        {
            return _board.Children[0].Inputs;
        }

        //needs a loop to return all circuis
        public List<NodeTemplate> getNodes()
        {
            return _board.Children[0].Nodes;
        }

        //needs a loop to return all circuis
        public List<NodeTemplate> getProbes()
        {
            return _board.Children[0].Probes;
        }

    }
}
