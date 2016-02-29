using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareX.HelpersLib
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this byte num,int min,int max)
        {
            return num >= min && num <= max;
        }
    }
}
