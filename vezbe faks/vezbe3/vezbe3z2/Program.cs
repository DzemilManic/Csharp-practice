using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace vezbe3z2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("unesite b");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("unesite c");
            int c = int.Parse(Console.ReadLine());
            // izracunati kvadrat broja a kroz f-ju
            //Func < int, int> kvadrat = w => w * w;
            //int ka = kvadrat(a);
            //Console.WriteLine($"kvadrat broja {a} = {ka}");

            Func<int, int, int> proizvod = (z,t) => z * t;
            int pr = proizvod(b, c);
            Console.WriteLine($"proizvod brojeva {b} i {c} = {pr}");

            Console.ReadLine();
        }
    }
}
