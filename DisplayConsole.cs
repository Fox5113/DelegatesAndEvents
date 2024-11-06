using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class DisplayConsole : IDisplay
    {
        public DisplayConsole(string caption)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = caption;
        }

        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public void DisplayMessageWithInterval(string message)
        {
            Console.WriteLine($"\n{message}");
        }

    }
}
