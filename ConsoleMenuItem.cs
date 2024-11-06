using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class ConsoleMenuItem
    {
        private readonly string _name;
        private readonly int _captionLevel;
        private readonly bool _isEnabled;
        private readonly EventHandler<EventArgs> _selected;

        public string Name => _name;
        public int CaptionLevel => _captionLevel;
        public bool IsEnabled => _isEnabled;
        public EventHandler<EventArgs> Selected => _selected;

        public ConsoleMenuItem(string name, int captionLevel = 0, EventHandler<EventArgs> selected = null)
        {
            _name = name;
            _captionLevel = captionLevel;

            if (selected == null)
            {
                _isEnabled = false;
            }
            else
            {
                _isEnabled = true;
            }

            _selected = selected;

            if (_isEnabled && _selected == null) 
                throw new ArgumentException(MessagesConst.ErrorNotFoundHandler);
        }
    }
}
