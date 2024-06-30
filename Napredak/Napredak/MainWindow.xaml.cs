using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Napredak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObavestivaStvar
    {
        private Aktivan_posao aktivanPosao;
        private Simulirani_posao simuliraniPosao;
        private Pravougaoni_indikator pravougaoniIndikator;
        private Kruzni_indikator kruzniIndikator;

        public MainWindow()
        {
            InitializeComponent();

            pravougaoniIndikator = new Pravougaoni_indikator(pravougaoniCanvas, Colors.Blue);
            kruzniIndikator = new Kruzni_indikator(kruzniCanvas, Colors.Red);

            Napredak napredakPravougaoni = new Napredak(pravougaoniIndikator);
            Napredak napredakKruzni = new Napredak(kruzniIndikator);

            aktivanPosao = new Aktivan_posao(10, 3, napredakPravougaoni);
            simuliraniPosao = new Simulirani_posao(1000, 5000); // Minimalno 1s, maksimalno 5s

            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += (sender, e) =>
            {
                if (aktivanPosao.Radi)
                {
                    btnKreni.IsEnabled = false;
                    btnZaustavi.IsEnabled = true;
                }
                else
                {
                    btnKreni.IsEnabled = true;
                    btnZaustavi.IsEnabled = false;
                }
            };
            timer.Start();
        }

        private void BtnKreni_Click(object sender, RoutedEventArgs e)
        {
            aktivanPosao.Pokreni();
            simuliraniPosao.Pokreni();
            btnKreni.IsEnabled = false;
            btnZaustavi.IsEnabled = true;
        }

        private void BtnZaustavi_Click(object sender, RoutedEventArgs e)
        {
            aktivanPosao.PrivremenoZaustavi();
            simuliraniPosao.PrivremenoZaustavi();
            btnKreni.IsEnabled = true;
            btnZaustavi.IsEnabled = false;
        }

        public void ObavestiNapredak(int procenat)
        {
            pravougaoniIndikator.Azuriraj(procenat);
            kruzniIndikator.Azuriraj(procenat);
        }
    }
}
