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

namespace Pong_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer ds = new DispatcherTimer();
        int Xsmer = 1, Ysmer = 1;
        int pomerajIgraca = 10, score = 0;
        float Xbrzina = 1f, Ybrzina = 1f, Xpomeraj, Ypomeraj = 0f;
        public MainWindow()
        {
            InitializeComponent();
            podloga.Focus();
            ds.Interval = TimeSpan.FromMilliseconds(20);
            ds.Tick += ds_Tick;
            ds.Start();
            Random r = new Random();
            Xpomeraj = r.Next((int)igrac1.Width, (int)this.Width);
        }

        private void ds_Tick(object sender, EventArgs e)
        {
            if(Canvas.GetLeft(lopta) < igrac1.Width || Canvas.GetLeft(lopta) + lopta.Width > this.ActualWidth - igrac2.Width)
            {
                MessageBox.Show($"Kraj igre, osvojili ste {score} poena");
                ds.Stop();
                return;
            }
            if(Canvas.GetTop(lopta) <= 0 || Canvas.GetTop(lopta) + lopta.Height >= this.ActualHeight - 50)
            {
                Ysmer = -Ysmer;
                Ybrzina += Ysmer * 1.5f;
            }
            Rect rlopta = new Rect(Canvas.GetLeft(lopta), Canvas.GetTop(lopta), lopta.Width, lopta.Height);
            Rect rigrac1 = new Rect(Canvas.GetLeft(igrac1), Canvas.GetTop(igrac1), igrac1.Width, igrac1.Height);
            Rect rigrac2 = new Rect(Canvas.GetLeft(igrac2), Canvas.GetTop(igrac2), igrac2.Width, igrac2.Height);

            if (rigrac2.IntersectsWith(rlopta) || rigrac1.IntersectsWith(rlopta))
            {
                Xsmer = -Xsmer;
                Xbrzina += Xsmer * 1.5f;
                score++;
            }
            Xpomeraj += Xbrzina;
            Ypomeraj += Ybrzina;

            Canvas.SetLeft(lopta, (Xbrzina + Xpomeraj));
            Canvas.SetTop(lopta, (Ybrzina + Ypomeraj));
        }
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down && Canvas.GetTop(igrac1) + igrac1.Height < this.ActualHeight - 50)
            {
                Canvas.SetTop(igrac1, Canvas.GetTop(igrac1) + pomerajIgraca);
            }
            if (e.Key == Key.Up && Canvas.GetTop(igrac1) > 0)
            {
                Canvas.SetTop(igrac1, Canvas.GetTop(igrac1) - pomerajIgraca);
            }
            if (e.Key == Key.S && Canvas.GetTop(igrac2) + igrac2.Height < this.ActualHeight - 50)
            {
                Canvas.SetTop(igrac2, Canvas.GetTop(igrac2) + pomerajIgraca);
            }
            if (e.Key == Key.W && Canvas.GetTop(igrac2) > 0)
            {
                Canvas.SetTop(igrac2, Canvas.GetTop(igrac2) - pomerajIgraca);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ds.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ds.Stop();
        }

        
    }
}
