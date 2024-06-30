using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Autoput
{
    internal class AktivnaTraka
    {
        public double Duzina { get; }
        public int Brzina { get; set; }
        DispatcherTimer timer;
        AktivnaRampa rampa;
        private List<Auto> autaNaTraci;
        private bool radi;
        public AktivnaTraka(double duzina, int brzina, string traka, int tmin, int tmax, int deltaT)
        {
            Duzina = duzina;
            Brzina = brzina;
            rampa = new AktivnaRampa(tmin, tmax, traka);
            autaNaTraci = new List<Auto>();

            radi = false;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(deltaT);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(radi)
            {
                var protekloVreme = timer.Interval.TotalMilliseconds;
                foreach(Auto auto in autaNaTraci)
                {
                    auto.AzurirajPut(protekloVreme);
                }
                autaNaTraci.RemoveAll(auto => auto.predjenPut >= Duzina);
                autaNaTraci.AddRange(rampa.DohvatiAutomobile());
                rampa.DohvatiAutomobile().Clear();
            }
        }
        public void PokreniTraku()
        {
            if (!radi)
            {
                radi = true;
                rampa.RadiRampa();
                timer.Start();
            }
        }
        public void PrivremenoZaustaviTraku()
        {
            radi = false;
            rampa.PrivremenoZaustavljenaRampa();
        }
        public void ZaustaviTraku()
        {
            radi = false;
            rampa.PrestanakRadaRampe();
        }
        public void PostaviBrzinu(int brzina)
        {
            Brzina = brzina;
        }
        public List<Auto> DohvatiAutaNaTraci()
        {
            return autaNaTraci;
        }
    }
}
