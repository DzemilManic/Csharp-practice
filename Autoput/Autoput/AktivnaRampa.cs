using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Autoput
{
    internal class AktivnaRampa
    {
        public int Tmin { get; set; }
        public int Tmax { get; set; }
        public Random random = new Random();
        private List<Auto> automobili;
        private DispatcherTimer timer;
        public bool radi { get; set; }
        public string Rampa { get; set; }
        public AktivnaRampa(int tmin, int tmax, string rampa)
        {
            Tmin = tmin;
            Tmax = tmax;
            Rampa = rampa;
            automobili = new List<Auto>();

            radi = false;
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(random.Next(Tmin, Tmax));
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (radi)
            {
                var auto = new Auto();
                automobili.Add(auto);

            }
        }
        public void RadiRampa()
        {
            if (!radi)
            {
                radi = true;
                timer.Start();
            }
        }
        public void PrivremenoZaustavljenaRampa()
        {
            radi = false;
        }
        public void PrestanakRadaRampe()
        {
            radi = false;
            timer.Stop();
        }
        public List<Auto> DohvatiAutomobile()
        {
            return new List<Auto>(automobili);
        }
    }
}
