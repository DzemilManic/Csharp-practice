using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba2z2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AvioKompanija kompanija = new AvioKompanija(10);
            RedovniLet r1 = new RedovniLet("BG", "ZG", new DateTime(2024, 3, 25, 12, 30, 0), 10, 100);
            RedovniLet r2 = new RedovniLet("SA", "ZG", new DateTime(2024, 3, 29, 1, 00, 0), 100, 100);
            CharterLet c1 = new CharterLet("BG", "ZG", new DateTime(2024, 3, 25, 12, 30, 0), 140, 100, 50);
            kompanija.DodajLet(r1);
            kompanija.DodajLet(r2);
            kompanija.DodajLet(c1);
            Console.WriteLine(kompanija.ToString());
            kompanija.RezervisiKartu("BG", "ZG", new DateTime(2024, 3, 15, 12, 30, 00));
            kompanija.RezervisiKartu("SA", "ZG", new DateTime(2024, 3, 29, 1, 00, 00));
        }
    }
}
