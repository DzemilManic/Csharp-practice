using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Krstarenje_jun24
{
    internal class AktivanBrod
    {
		private string imeBroda;
		private Canvas podlogaBrod;
		private int tui = 20, tp = 3000, tb = 300;
		private DispatcherTimer brodUlazakIzlazak = new DispatcherTimer();
		private DispatcherTimer brodPlovidba = new DispatcherTimer();
		private DispatcherTimer brodBoravak = new DispatcherTimer();

		public AktivnaLuka PrvaLuka { get; set; }
		public AktivnaLuka DrugaLuka { get; set; }
		private AktivnaLuka trenutnaLuka { get; set; }
		public Canvas PodlogaBrod
		{
			get { return podlogaBrod; }
			set { podlogaBrod = value; }
		}
		public string ImeBroda
		{
			get { return imeBroda; }
			set { imeBroda = value; }
		}

		public Red Putnici { get; set; }
		public AktivanBrod(string i, Red r, AktivnaLuka lPolazna, AktivnaLuka lDolazna)
		{
			imeBroda = i;
			Putnici = r;
			PrvaLuka = lPolazna;
			DrugaLuka = lDolazna;
			trenutnaLuka = PrvaLuka;

			brodUlazakIzlazak.Interval = TimeSpan.FromMilliseconds(tui);
			brodUlazakIzlazak.Tick += UlazakIzlazak_Tick;
			brodPlovidba.Interval = TimeSpan.FromMilliseconds(tp);
			brodPlovidba.Tick += Plovidba_Tick;
			brodBoravak.Interval = TimeSpan.FromMilliseconds(tb);
			brodBoravak.Tick += Boravak_Tick;
			Pokreni();
		}

        public void Pokreni()
        {
            brodUlazakIzlazak.Start();
        }
        private void Boravak_Tick(object sender, EventArgs e)
        {
            brodBoravak.Stop();
            if (trenutnaLuka == PrvaLuka)
            {
                trenutnaLuka = DrugaLuka;
            }
            else
            {
                trenutnaLuka = PrvaLuka;
            }

            brodUlazakIzlazak.Start();
        }

        private void Plovidba_Tick(object sender, EventArgs e)
        {
            brodPlovidba.Start();
            brodBoravak.Stop();
        }

        private void UlazakIzlazak_Tick(object sender, EventArgs e)
        {
            if (trenutnaLuka == PrvaLuka)
            {
                try
                {
                    Putnik p = trenutnaLuka.NaredniPutnik();
                    Putnici.StaviPutnika(p);
                }
                catch (ThreadInterruptedException)
                {
                    // Ignorisi
                }
            }
            else
            {
                try
                {
                    Putnik p = Putnici.UzmiPutnika();
                    trenutnaLuka.Red.StaviPutnika(p);
                }
                catch (ThreadInterruptedException)
                {
                    // Ignorisi
                }
            }

            if (Putnici.jeLiPun() || trenutnaLuka.Red.jeLiPrazan())
            {
                brodUlazakIzlazak.Stop();
                brodPlovidba.Start();
            }
        }
        public void Zaustavi()
        {
            brodUlazakIzlazak.Stop();
            brodPlovidba.Stop();
            brodBoravak.Stop();
        }
        public string FazaVoznje()
        {
            if (brodUlazakIzlazak.IsEnabled)
            {
                return "Ulazak/Izlazak";
            }
            if (brodPlovidba.IsEnabled)
            {
                return "Plovidba";
            }
            if (brodBoravak.IsEnabled)
            {
                return "Boravak";
            }
            return "N/A";
        }
        public void PopuniPanel()
        {
            var ime = new TextBlock { Text = $"{ImeBroda}" };
            Canvas.SetLeft(ime, 10);
            Canvas.SetTop(ime, 10);

            var cb = new CheckBox { Content = "Plovi" };
            Canvas.SetLeft(cb, 30);
            Canvas.SetTop(cb, 10);

            // Event handler za kada se stiklira CheckBox
            cb.Checked += (s, e) =>
            {
                Console.WriteLine("CheckBox Checked: Brod pokreće plovidbu");
                Pokreni();
            };

            // Event handler za kada se odstiklira CheckBox
            cb.Unchecked += (s, e) =>
            {
                Console.WriteLine("CheckBox Unchecked: Brod zaustavlja plovidbu");
                Zaustavi();
            };

            // Dodajte CheckBox u Canvas
            PodlogaBrod.Children.Add(ime);
            PodlogaBrod.Children.Add(cb);
        }
    }
}
