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
        private FileSelectorFactory _fileSelectorFactory;

        public ObservableCollection<string> FileNames { get; set; }
        public ObservableCollection<NodeViewModel> Inputs { get; set; }
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
        public ObservableCollection<NodeViewModel> Probes { get; set; }

        private string _selectedFileName;
        public string SelectedFileName
        {
            get { return _selectedFileName; }
            set
            {
                _selectedFileName = value;
                RaisePropertyChanged("SelectedFileName");
             
                BuildCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand BuildCommand { get; set; }

        public MainViewModel()
        {
            _running = false;
            _mc = new MainController();

            BuildCommand = new RelayCommand(BuildCircuit, CanBuildCircuit);

            _fileSelectorFactory = FileSelectorFactory.GetInstance();
            FileNames = new ObservableCollection<string>(_fileSelectorFactory.getFileNames);
        }

        private void BuildCircuit()
        {
            string filepath = _fileSelectorFactory.GetFilePath(_selectedFileName);
            _mc.BuildCircuit(filepath);

            Inputs = new ObservableCollection<NodeViewModel>(_mc.getInputs().Select(i => new NodeViewModel(i)));
            Nodes = new ObservableCollection<NodeViewModel>(_mc.getNodes().Select(n => new NodeViewModel(n)));
            Probes = new ObservableCollection<NodeViewModel>(_mc.getProbes().Select(p => new NodeViewModel(p)));

        }

        private bool CanBuildCircuit()
        {
            return SelectedFileName != null ? true : false;
        }
       
    }
}