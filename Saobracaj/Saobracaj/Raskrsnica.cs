using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Saobracaj
{
    internal class Raskrsnica
    {
        private Ulica ulica;
        private Evidencija evidencija;
        private DispatcherTimer timer;

        public Raskrsnica(Ulica ulica, Evidencija evidencija, int interval = 2000)
        {
            this.ulica = ulica;
            this.evidencija = evidencija;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Tick += Timer_Tick;
        }

        public void Pokreni()
        {
            timer.Start();
        }

        public void Zaustavi()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Aktivnost();
        }

        public void Aktivnost()
        {
            string opisSnimka = ulica.UzmiVozilo();
            if (opisSnimka != null)
            {
                evidencija.DodajSnimak(opisSnimka);
                Console.WriteLine($"Додат снимак у евиденцију: {opisSnimka}");
            }
        }
    }
}

