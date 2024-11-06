using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class ItemAddedEventArgs<T> : EventArgs
    {
        public T AddedItem { get; }

        public ItemAddedEventArgs(T addedItem)
        {
            AddedItem = addedItem;
        }
    }
}
