using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Krstarenje_jun24
{
    internal class AktivnaLuka
    {
        private string imeLuke;
        private Canvas podlogaLuka;
        private Random random = new Random();
        private int tsr = 500;
        private DispatcherTimer lukaTimer = new DispatcherTimer();
        public Red Red;

        public Canvas PodlogaLuka
        {
            get { return podlogaLuka; }
            set { podlogaLuka = value; }
        }

        public string ImeLuke
        {
            get { return imeLuke; }
            set { imeLuke = value; }
        }
        public AktivnaLuka(string i, Red r)
        {
            ImeLuke = i;
            Red = r;
            int interval = random.Next(tsr * 80 / 100, tsr * 120 / 100);
            lukaTimer.Interval = TimeSpan.FromMilliseconds(interval);
            lukaTimer.Tick += LukaTimer_Tick;
            Otvori();
        }

        private void LukaTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Putnik p = new Putnik();
                Red.StaviPutnika(p);
            }
            catch
            {
                //nesto
            }
        }
        private bool isActive = false;
        public void Otvori()
        {
            if (!isActive)
            {
                isActive = true;
                lukaTimer.Start();

            }
        }
        public void Zatvori()
        {
            if (isActive)
            {
                isActive = false;
                lukaTimer.Stop();
                Red.IsprazniRed();
            }
        }
        public void Unisti()
        {
            Zatvori();
        }
        public int DohvatiBrPutnika()
        {
            return Red.BrojPutnika();
        }
        public Putnik NaredniPutnik()
        {
            return Red.UzmiPutnika();
        }
        public void PopuniPanel()
        {
            var ime = new TextBlock { Text = $"{ImeLuke}" };
            Canvas.SetTop(ime, 10);
            Canvas.SetLeft(ime, 10);

            var cb = new CheckBox { Content = "Otvorena" };
            Canvas.SetTop(cb, 50);
            Canvas.SetLeft(cb, 10);

            cb.Checked += (s, e) =>
            {
                Console.WriteLine($"CheckBox Checked: Luka {ImeLuke} je otvorena");
                Otvori();
            };

            cb.Unchecked += (s, e) =>
            {
                Console.WriteLine($"CheckBox Unchecked: Luka {ImeLuke} je zatvorena");
                Zatvori();
            };

            var redOpis = new TextBlock();
            redOpis.Text = Red.ToString();
            Canvas.SetLeft(redOpis, 10);
            Canvas.SetTop(redOpis, 70);

            Red.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Red.RedPutnika))
                {
                    redOpis.Text = Red.ToString();
                }
            };

            PodlogaLuka.Children.Add(ime);
            PodlogaLuka.Children.Add(cb);
            PodlogaLuka.Children.Add(redOpis);
        }
    }
}
