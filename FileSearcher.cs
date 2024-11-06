using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> OnFileFound;

        public void Search(string directory)
        {
            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                var args = new FileArgs(file);
                FileFound(args);

                if (args.Cancel)
                {
                    BaseConsoleActions.display.DisplayMessageWithInterval(MessagesConst.SearchFileCancel);
                    return;
                }
            }
        }
        protected virtual void FileFound(FileArgs e)
        {
            OnFileFound?.Invoke(this, e);
        }
    }
}
