using System.Diagnostics;

namespace DelegatesAndEvents
{
    public class Program
    {
        static void Main(string[] args)
        {
            BaseConsoleActions.PrepareConsole(MessagesConst.DelegateEvent);

            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            ConsoleMenu menu = new ConsoleMenu(MessagesConst.MenuCaption)
            {
                MenuItems =
                {
                    new ConsoleMenuItem(MessagesConst.GroupIEnumerable),
                    new ConsoleMenuItem(MessagesConst.CallGetMin, 1, (s, e) => { BaseIEnumerableAction(list => CallIEnumerableGetMin(list)); }),
                    new ConsoleMenuItem(MessagesConst.CallGetMax, 1, (s, e) => { BaseIEnumerableAction(list => CallIEnumerableGetMax(list)); }),
                    new ConsoleMenuItem(MessagesConst.CallGetAverage, 1, (s, e) => { BaseIEnumerableAction(list => CallIEnumerableGetAverage(list)); }),
                    new ConsoleMenuItem(MessagesConst.GroupFile),
                    new ConsoleMenuItem(MessagesConst.ShowFilesFromFolder, 1, (s, e) => { SearchFilesByFile(); }),
                    new ConsoleMenuItem(MessagesConst.Explorer, 1, (s, e) => { ShowExplorer(); }),
                    new ConsoleMenuItem(MessagesConst.Exit, 0, (s, e) => { BaseConsoleActions.Exit(); })
                }
            };
            menu.OnItemAdded += (sender, e) =>
            {
                menu.DisplayMenu();
            };
            menu.DisplayMenu();
        }

        private static void ShowExplorer(string path = "")
        {
            string label = string.IsNullOrEmpty(path) ? MessagesConst.Explorer : $"{MessagesConst.Explorer}: {path}";
            ConsoleMenu menu = new ConsoleMenu(label);
            Explorer explorer = new Explorer();
            explorer.OnItemFound += (object sender, ExplorerArgs e) => { OnExplorerItemFound(sender, e, menu); };

            if (string.IsNullOrEmpty(path))
            {
                menu.MenuItems.Add(new ConsoleMenuItem(MessagesConst.Down, 0, (s, e) => { ShowMainMenu(); }));
                explorer.SearchDrives();
            }
            else
            {
                if (explorer.GetAvailableDrives().Contains(path))
                {
                    menu.MenuItems.Add(new ConsoleMenuItem("..", 0, (s, e) => { ShowExplorer(); }));
                }
                else
                {
                    menu.MenuItems.Add(new ConsoleMenuItem("..", 0, (s, e) => {
                        ShowExplorer(Directory.GetParent(path)?.FullName); 
                    }));
                }
                explorer.Search(path);
            }

            menu.OnItemAdded += (sender, e) =>
            {
                menu.DisplayMenu();
            };
            menu.DisplayMenu();
        }

        private static void OnFileFound(object sender, FileArgs e)
        {
            BaseConsoleActions.display.DisplayMessage($"\n{MessagesConst.FileNotFound} {e.FileName}");
            if (e.FileName.Contains(MessagesConst.NameForCancel))
                e.Cancel = true;
        }

        private static void OnExplorerItemFound(object sender, ExplorerArgs explorerArgs, ConsoleMenu menu)
        {
            if (explorerArgs.Name.Contains(MessagesConst.NameForCancel))
                explorerArgs.Cancel = true;

            if (explorerArgs.IsDrive || explorerArgs.IsFolder)
            {
                menu.MenuItems.Add(new ConsoleMenuItem(explorerArgs.Name, 0, (s, e) => { ShowExplorer(explorerArgs.FullPath); }));
            }
            else
            {
                menu.MenuItems.Add(new ConsoleMenuItem(explorerArgs.Name, 0, (s, e) => { OpenFile(explorerArgs.FullPath); }));
            }
        }

        private static void SearchFilesByFile()
        {
            string path = BaseConsoleActions.AskForValidDirectoryPath();
            if (path == MessagesConst.NameForCancel)
            {
                BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
                return;
            }
            FileSearcher fileSearcher = new FileSearcher();
            fileSearcher.OnFileFound += OnFileFound;
            fileSearcher.Search(path);
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private static void OpenFile(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{MessagesConst.ErrorOpenFile} {ex.Message}");
            }
        }

        private static void CallIEnumerableGetMin(List<Randomaser> list)
        {
            var result = list.GetMin(item => item.Value);
            BaseConsoleActions.display.DisplayMessageWithInterval($"{MessagesConst.TMost} {result.Value}");
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private static void CallIEnumerableGetMax(List<Randomaser> list)
        {
            var result = list.GetMax(item => item.Value);
            BaseConsoleActions.display.DisplayMessageWithInterval($"{MessagesConst.THighest} {result.Value}");
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private static void CallIEnumerableGetAverage(List<Randomaser> list)
        {
            var result = list.GetAverage(item => item.Value);
            BaseConsoleActions.display.DisplayMessageWithInterval($"{MessagesConst.TMeaning} {result}");
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private static void BaseIEnumerableAction(Action<List<Randomaser>> invokeAction)
        {
            int count = BaseConsoleActions.AskForValidIntegerInput($"{MessagesConst.GreaterZeroCollection} ", value => value > 0);
            int rangeStart = BaseConsoleActions.AskForValidIntegerInput($"{MessagesConst.StartValueCollection} ");
            int rangeEnd = BaseConsoleActions.AskForValidIntegerInput($"{MessagesConst.EndValueCollection} ", value => value > rangeStart);

            List<Randomaser> list = new List<Randomaser>();
            for (int i = 0; i <= count - 1; i++)
            {
                list.Add(new Randomaser(rangeStart, rangeEnd));
            }

            BaseConsoleActions.display.DisplayMessageWithInterval($"{MessagesConst.GeneratedData}\n{string.Join("; ", list.Select(x => $"Name: {x.Name}, Value: {x.Value}"))}");
            invokeAction(list);
        }
    }
}
