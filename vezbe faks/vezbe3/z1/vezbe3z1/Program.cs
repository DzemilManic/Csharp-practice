using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe3z1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            slikaProcesor slikaProcesor = new slikaProcesor();
            slikaFilter filters = new slikaFilter();
            slikaProcesor.SlikaProcesorDelegat delegat = 
            slikaProcesor.Process("https://dunp.ac.rs/Images/Profiles/SI.png");
            Console.ReadKey();
        }
        public static void Clean() {
            Console.WriteLine("Primenili ste filtere za ciscenje slike");
        }
    }
}
