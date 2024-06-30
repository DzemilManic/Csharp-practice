using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Napredak
{
    internal class Aktivan_posao
    {
        private int brojPonavljanja;
        private int kInterval;
        private bool radi;
        private Thread thread;
        private IObavestivaStvar obavestivaStvar;
        public bool Radi => radi;
        public Aktivan_posao(int brojPonavljanja, int kInterval, IObavestivaStvar obavestivaStvar)
        {
            this.brojPonavljanja = brojPonavljanja;
            this.kInterval = kInterval;
            this.obavestivaStvar = obavestivaStvar;
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
        }
        public void TrajnoPrekini()
        {
            radi = false;
            thread.Join();
        }
        private void IzvrsiPosao()
        {
            for (int i = 0; i < brojPonavljanja; i++)
            {
                Thread.Sleep(500);

                if (i % kInterval == 0)
                {
                    obavestivaStvar.ObavestiNapredak((i * 100) / brojPonavljanja);
                }
                if (!radi)
                {
                    break;
                }
            }
            radi = false;
        }
    }
}
