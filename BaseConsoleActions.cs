using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class BaseConsoleActions
    {
        public static IDisplay display ;
        public static int AskForValidIntegerInput(string question, Func<int, bool> additionalCheck = null)
        {
            display.DisplayMessage(question);

            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) &&
                (additionalCheck == null  || additionalCheck(result))))
            {
            }

            return result;
        }

        public static string AskForValidDirectoryPath()
        {
            display.DisplayMessageWithInterval(MessagesConst.PathFolder);
            while (true)
            {
                var read = Console.ReadLine();
                string path = StringManipulations.IsNULL(read);
                if (Directory.Exists(path)) return path;
                if (path.Equals(MessagesConst.NameForCancel, StringComparison.OrdinalIgnoreCase)) return MessagesConst.NameForCancel;
                display.DisplayMessageWithInterval(MessagesConst.PathNotValid);
            }
        }


        public static void PrepareConsole(string caption)
        {
            display = new DisplayConsole(caption);
        }

        public static void PressAnyToContinue(Action continueAction)
        {
            display.DisplayMessageWithInterval(MessagesConst.PressAnyToContinue);
            Console.ReadKey();

            continueAction();
        }

        public static void Exit()
        {
            display.DisplayMessageWithInterval(MessagesConst.ExitMessage);
            Environment.Exit(0);
        }
    }
}
