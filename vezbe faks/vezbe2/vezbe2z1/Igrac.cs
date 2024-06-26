using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe2z1
{
    internal class Igrac
    {
        private int broj;
        public int Broj
        {
            get { return broj; }
            set
            {
                if (value >= 1 && value <= 10)
                    broj = value;
                else
                {
                    Console.WriteLine("neispravan unos");
                    broj = -1;
                }
            }
        }

        public Igrac()
        {

        }
        public void GetBroj()
        {
            Console.WriteLine("unesite zamisljeni broj");
            string saKonzole = Console.ReadLine();
            Broj = int.Parse(saKonzole);
        }
    }
}
