using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public static class StringManipulations
    {
        public static string IsNULL(string? str)
        {
            string result = str != null ? str.ToString() : string.Empty;
            return result;
        }
    }
}
