using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogischCircuit.Base;
using LogischCircuit.Builder;
using LogischCircuit.Interface;
using LogischCircuit.Model;
using LogischCircuit.Registries;
using LogischCircuit.ViewModel;

namespace LogischCircuit.Controller
{
    class MainController
    {

        private MainViewModel _mv;
        private Circuit _circuit;

        public MainController(MainViewModel mv)
        {
            _mv = mv;

            //register strategies to singleton factories
            Registry.RegisterStrategies();
        }

        public Circuit GetCircuit()
        {
            return _circuit;
        }

        public bool BuildCircuit(string filepath)
        {
            CircuitBuilder cb = new CircuitBuilder();
            if (!cb.Create(filepath))
            {
                _mv.ErrorMessage = cb.ErrorMessage;
                return false;
            }
            _mv.ErrorMessage = cb.ErrorMessage;
            _circuit = cb.Build();
            _circuit.Inputs.ForEach(inp => inp.InfiniteLoop(null));
            return true;
        }

        public void SetStates()
        {
            _circuit.SetStates();
        }

        public void Run()
        {
            SetStates();
            _circuit.Calculate();
        }

        //needs a loop to return all circuis
        public List<NodeBase> getInputs()
        {
            return _circuit.Inputs;
        }

        //needs a loop to return all circuis
        public List<NodeBase> getNodes()
        {
            return _circuit.Nodes;
        }

        //needs a loop to return all circuis
        public List<NodeBase> getProbes()
        {
            return _circuit.Outputs;
        }

    }
}
