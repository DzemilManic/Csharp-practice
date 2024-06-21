using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe1z4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Racun[] racuni = new Racun[3];
            racuni[0] = new Racun("Dzemil", 300000, "200-1545515456465-216");
            racuni[1] = new Racun("Ajsa", 400000, "200-145645456465-216");
            racuni[2] = new Racun("Nejla", 350000, "200-1546846545665-216");

            racuni[0].uvecanje(160000);
            racuni[1].umanjenje(56000);
            racuni[2].umanjenje(60000);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(racuni[i]);
            }
            Console.ReadLine();
        }

    }

}


