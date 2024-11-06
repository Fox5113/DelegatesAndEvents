using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Randomaser
    {
        private string _name;
        private float _value;

        public string Name => _name;
        public float Value => _value;

        public Randomaser(int rangeStart, int rangeEnd)
        {
            if (rangeEnd <= rangeStart)
                throw new ArgumentException(MessagesConst.RangeEx);
            Random random = new Random();
            double range = rangeEnd - rangeStart;
            _value = (float)(random.NextDouble() * range + rangeStart);
            _name = $"{nameof(Randomaser)} - {Value}";
        }
    }
}
