using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Autoput
{
    internal class Auto
    {
        private Random random = new Random();
        private string letters = "ABVGDEZIJKLMNOPRSTUFHC";
        public string registarskaOznaka { get; set; }
        public int Brzina { get; set; }
        public double predjenPut { get; set; }
        private DateTime vremeKreiranja { get; set; }
        public Auto(int Vmin = 60, int Vmax = 200)
        {
            registarskaOznaka = GenirisiRegistraciju();
            Brzina = random.Next(Vmin, Vmax);
            predjenPut = 0;
            vremeKreiranja = DateTime.Now;
        }

        private string GenirisiRegistraciju()
        {
            char slovo = letters[random.Next(letters.Length)];
            int broj = random.Next(100, 1000);
            return $"{slovo}:{broj}";
        }
        public void AzurirajPut(double deltaT)
        {
            predjenPut += Brzina * (deltaT / 1000.0);
        }
        private string Opis()
        {
            return $"{registarskaOznaka}({Brzina})";
        }
    }
}
