using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public interface  IDisplay
    {
        public abstract  void DisplayMessage(string message);
        public abstract  void DisplayMessageWithInterval(string message);
    }
}
