using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Factory
{

    // factory to get all the files and file names in the Circuits folder
    // also has a singelton pattern
    public class FileSelectorFactory
    {
        Dictionary<string, string> _files;
        private static FileSelectorFactory _instance = null;

        public IEnumerable<string> getFileNames()
        {
            return _files.Keys; 
        }

        public FileSelectorFactory()
        {
            _instance = this;
            _files = new Dictionary<string, string>();
            ReadFiles();
        }

        private void ReadFiles()
        {
            int i = 0;

            foreach (string file in Directory.GetFiles("../../../Circuits"))
            {
                _files.Add(Path.GetFileNameWithoutExtension(file),file);
            }
        }

        public string GetFilePath(string key)
        {
            return _files[key];
        }

        //singelton pattern
        public static FileSelectorFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileSelectorFactory();
            }

            return _instance;
        }


    }
}
