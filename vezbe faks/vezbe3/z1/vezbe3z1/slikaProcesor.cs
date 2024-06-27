using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vezbe3z1
{
    internal class slikaProcesor
    {
        public delegate void SlikaProcesorDelegate(slika slika);
        public void Process(string url, SlikaProcesorDelegate handler)
        {
            slika slika = new slika();
            Console.WriteLine("ucitali smo baznu sliku, krecemo sa izmenama");
            Thread.Sleep(3000);

            handler(slika);
            //slikaFilter.ApplyRedBackground(slika);
            //slikaFilter.ApplyIncreaseBrig(slika);
            slika.Save();
        }
    }
}
