using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogischCircuit.Factory
{
    public class FileSelectorFactory
    {
        Dictionary<string, string> _files;

        public IEnumerable<string> getFileNames
        {
            get { return _files.Keys; }
        }

        public FileSelectorFactory()
        {
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


    }
}
