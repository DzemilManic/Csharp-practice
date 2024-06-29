using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Restoran
{
    internal class Aktivan_sto
    {
        private int Id { get; set; }
        private int globalniId = 0;
        private Meni meni;
        private Pult pult;
        private bool radi;
        private Thread thread;
        public Aktivan_sto(Meni meni, Pult pult)
        {
            this.meni = meni;
            this.pult = pult;
            Id = globalniId++;
            radi = true; 
        }
        public void Pokreni()
        {
            while(radi)
            {
                var random = new Random();
                var porudzbina = GenerisiSlucajnuPorudzbinu();
                pult.DodajPorudzbinu(porudzbina);
                Thread.Sleep(random.Next(4,7));
            }
        }
        public void PrivremenoZaustavi()
        {
            radi = false;
        }
        public void TrajnoPrekini()
        {
            radi = false;
            thread.Join();
        }

        private Porudzbina GenerisiSlucajnuPorudzbinu()
        {
            var random = new Random();
            int brojJela = random.Next(1, 4);
            var porucenaJela = new List<Jelo>();
            for(int i = 0; i <  brojJela; i++)
            {
                int indeksJela = random.Next(0, meni.ukupnoJela);
                porucenaJela.Add(meni.DohvatiPoIndeksu(indeksJela));
            }
            return new Porudzbina(Id, porucenaJela);
        }

    }
}
