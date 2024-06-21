using System;

namespace vezbe1z3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite stranicu kvadrata");
            string saKonzole = Console.ReadLine();
            float stranica = float.Parse(saKonzole);
            Kvadrat k = new Kvadrat(stranica);
            Console.WriteLine("obim kvadrata je " + k.Obim() + " , a njegova povrsina je " + k.Povrsina());

            Console.WriteLine("Unesite poluprecnik kruga");
            saKonzole = Console.ReadLine();
            float pp = float.Parse(saKonzole);
            Krug kr = new Krug(pp);
            Console.WriteLine("obim kruga je " + kr.Obim() + " , a njegova povrsina je " + kr.Povrsina());
            Console.Read();
        }
    }
}
