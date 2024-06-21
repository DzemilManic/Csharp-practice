using System;

namespace vezbe1z2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("unesite tekst");
            string Tekst = Console.ReadLine();
            string IzlazniTekst = "";
            for(int i = 0; i < Tekst.Length; i++)
            {
                char Znak = Tekst[i];
                int asciiZnak = (int)Znak;
                Console.WriteLine("Trenutno slovo je {0} i ima ASCII vrednost {1}", Znak, asciiZnak);

                asciiZnak++;
                char NoviZnak = (char)asciiZnak;
                Console.WriteLine("Novi karakter je {0} i ima ASCII vrednost {1}", NoviZnak, asciiZnak);
                IzlazniTekst += NoviZnak;
      
            }
            Console.WriteLine("Siforvan tekst je {0}", IzlazniTekst);
            Console.Read();
                
        }
    }
}