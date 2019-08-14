using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LogischCircuit.Controller;
using LogischCircuit.Factory;
using System.Linq;
using LogischCircuit.Adapter;

namespace LogischCircuit.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// is het netter om een decorator alleen een AND te noemen omdat hij al in de Decorator map staat????

    public class MainViewModel : ViewModelBase
    {
        private bool _running;
        private MainController _mc;
        private FileSelectorAdapter _fileSelectorFactoryAdapter;

        public ObservableCollection<string> FileNames { get; set; }
        public ObservableCollection<NodeViewModel> Inputs { get; set; }
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
        public ObservableCollection<NodeViewModel> Probes { get; set; }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                base.RaisePropertyChanged();
            }
        }

        private string _selectedFileName;
        public string SelectedFileName
        {
            get { return _selectedFileName; }
            set
            {
                _selectedFileName = value;
                RaisePropertyChanged();
                BuildCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand BuildCommand { get; set; }

        public MainViewModel()
        {
            _running = false;
            _mc = new MainController(this);

            BuildCommand = new RelayCommand(BuildCircuit, CanBuildCircuit);

            _fileSelectorFactoryAdapter = new FileSelectorAdapter(FileSelectorFactory.GetInstance());

            FileNames = new ObservableCollection<string>(_fileSelectorFactoryAdapter.getNames());
            Inputs = new ObservableCollection<NodeViewModel>();
            Nodes = new ObservableCollection<NodeViewModel>();
            Probes = new ObservableCollection<NodeViewModel>();
        }

        private void BuildCircuit()
        {
            string filepath = _fileSelectorFactoryAdapter.GetPathFromFile(_selectedFileName);
            _mc.BuildCircuit(filepath);

            Inputs.Clear();
            _mc.getInputs().ForEach(i => Inputs.Add(new NodeViewModel(i, this)));

            Nodes.Clear();
            _mc.getNodes().ForEach(i => Nodes.Add(new NodeViewModel(i, this)));

            Probes.Clear();
            _mc.getProbes().ForEach(i => Probes.Add(new NodeViewModel(i, this)));

            base.RaisePropertyChanged();
            _mc.Run();
        }

        private bool CanBuildCircuit()
        {
            return SelectedFileName != null ? true : false;
        }
       
    }
}