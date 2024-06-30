using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Napredak
{
    internal class Simulirani_posao
    {
        private int minimalnoVremeMs;
        private int maksimalnoVremeMs;
        private bool radi;
        private Thread thread;
        public bool Radi => radi;

        public Simulirani_posao(int minimalnoVremeMs, int maksimalnoVremeMs)
        {
            this.minimalnoVremeMs = minimalnoVremeMs;
            this.maksimalnoVremeMs = maksimalnoVremeMs;
            radi = true;
            thread = new Thread(IzvrsiPosao);
        }

        public void Pokreni()
        {
            thread.Start();
        }

        public void PrivremenoZaustavi()
        {
            radi = false;
        }

        public void Nastavi()
        {
            radi = true;
            thread = new Thread(IzvrsiPosao);
            thread.Start();
        }

        public void TrajnoPrekini()
        {
            radi = false;
            thread.Join();
        }

        private void IzvrsiPosao()
        {
            Random random = new Random();
            while (radi)
            {
                int vremeSpavanja = random.Next(minimalnoVremeMs, maksimalnoVremeMs + 1);
                Thread.Sleep(vremeSpavanja);
            }
            radi = false;
        }
    }
}
