using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
