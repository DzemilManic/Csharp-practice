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

namespace Krstarenje_jun24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Plovidba plovidba;
        public MainWindow()
        {
            InitializeComponent();
            Inicijalizuj();
        }
        private void Inicijalizuj()
        {
            var podlogaLuka1 = new Canvas { Width = 200, Height = 400, Background = System.Windows.Media.Brushes.LightBlue };
            Canvas.SetLeft(podlogaLuka1, 0);
            Canvas.SetTop(podlogaLuka1, 0);
            podloga.Children.Add(podlogaLuka1);

            var podlogaLuka2 = new Canvas { Width = 200, Height = 400, Background = System.Windows.Media.Brushes.LightGreen };
            Canvas.SetLeft(podlogaLuka2, 600);
            Canvas.SetTop(podlogaLuka2, 0);
            podloga.Children.Add(podlogaLuka2);

            var podlogaBrod = new Canvas { Width = 400, Height = 200, Background = System.Windows.Media.Brushes.LightGray };
            Canvas.SetLeft(podlogaBrod, 200);
            Canvas.SetTop(podlogaBrod, 200);
            podloga.Children.Add(podlogaBrod);

            plovidba = new Plovidba("Brod", 10, 15, 5, podlogaBrod, podlogaLuka1, podlogaLuka2);

            plovidba.PokreniPlovidbu();
        }
    }
}
