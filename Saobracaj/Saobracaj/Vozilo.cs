using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class Vozilo
    {
        public string[] Gradovi = { "BG", "NS", "NI" };
        public string RegistarskaOznaka { get; set; }
        public Random random;
        public Vozilo()
        {
            string grad = Gradovi[random.Next(Gradovi.Length)];
            int broj = random.Next(100, 1000);
            RegistarskaOznaka = $"{grad}:{broj}";
        }
        public override string ToString()
        {
            return RegistarskaOznaka;
        }
    }
}
