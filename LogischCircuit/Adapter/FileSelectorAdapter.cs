using LogischCircuit.Factory;
using LogischCircuit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Adapter
{
    class FileSelectorAdapter : IFileSelector
    {
        private FileSelectorFactory _fileSelectorFactory;

        public FileSelectorAdapter(FileSelectorFactory fsf)
        {
            _fileSelectorFactory = fsf;
        }

        public IEnumerable<string> getNames()
        {
           return _fileSelectorFactory.getFileNames();
        }

        public string GetPathFromFile(string name)
        {
            return _fileSelectorFactory.GetFilePath(name);
        }

    }
}
