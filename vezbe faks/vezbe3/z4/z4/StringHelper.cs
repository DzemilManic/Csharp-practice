using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z4
{
    public static class StringHelper
    {
        public static string ShortString(this string text, int numWords)
        {
            if(numWords <= 0) 
                return text;
            var words = text.Split(' ');
            var rez = string.Join(" ", words.Take(numWords)) + "...";
            return rez;
            
        }
    }
}
