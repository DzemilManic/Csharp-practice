using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Saobracaj
{
    internal class Saobracajnica
    {
        public List<SaobracajnaTraka> trake;
        private int tmin;
        private int tmax;
        private bool radi;

        public int Tmax
        {
            get { return tmax; }
            set { tmax = value; }
        }


        public int Tmin
        {
            get { return tmin; }
            set { tmin = value; }
        }

        public Random random = new Random();
        public DispatcherTimer timer;
        public Saobracajnica(int brojTraka, int tmin = 100, int tmax = 1000)
        {
            Tmin = tmin;
            Tmax = tmax;
            radi = false;
            random = new Random();
            trake = new List<SaobracajnaTraka>();
            for(int i = 0; i < brojTraka; i++)
            {
                trake.Add(new SaobracajnaTraka());
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(random.Next(tmin, tmax));
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (radi)
            {
                DodajVozilo();
            }
        }
        protected virtual void DodajVozilo()
        {
            Vozilo vozilo = new Vozilo();
            int indeksTrake = random.Next(trake.Count);
            trake[indeksTrake].DodajVozilo(vozilo);

        }
        public void Pokreni()
        {
            radi = true;
            timer.Start();
        }
        public void ZaustaviSkroz()
        {
            radi = false;
            timer.Stop();
        }
        public void PrivremenoZaustavi()
        {
            radi = false;
        }
        public void PromeniInterval(int novoMin, int novoMax)
        {
            Tmin = novoMin;
            Tmax = novoMax;
        }
    }
}
