﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Explorer
    {
        public event EventHandler<ExplorerArgs> OnItemFound;

        public void Search(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine(MessagesConst.FilePathNotFound);
                return;
            }

            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                var args = new ExplorerArgs(file, true);
                ItemFound(args);

                if (args.Cancel)
                {
                    BaseConsoleActions.display.DisplayMessageWithInterval(MessagesConst.SearchFileCancel);
                    return;
                }
            }

            var directories = Directory.GetDirectories(directory);
            foreach (var folder in directories)
            {
                var args = new ExplorerArgs(folder, false, true);
                ItemFound(args);

                if (args.Cancel)
                {
                    BaseConsoleActions.display.DisplayMessageWithInterval(MessagesConst.SearchFolderCancel);
                    return;
                }
            }
        }

        public List<string> GetAvailableDrives()
        {
            List<string> drives = new List<string>();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (var drive in allDrives)
            {
                if (drive.IsReady)
                    drives.Add(drive.Name);
            }

            return drives;
        }

        public void SearchDrives()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    var args = new ExplorerArgs(drive.Name, false, false, true);
                    ItemFound(args);
                }
            }
        }

        protected virtual void ItemFound(ExplorerArgs e)
        {
            OnItemFound?.Invoke(this, e);
        }
    }
}
