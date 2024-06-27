using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = "danas ucimo osnove prog jezika c#. bez osnova se ne moze dalje";
            var num = 5;
            //var shortString = StringHelper.ShortString(text, num);
            var shortString = text.ShortString(num);
            Console.WriteLine(shortString);
            Console.ReadLine();
        }
    }
}
