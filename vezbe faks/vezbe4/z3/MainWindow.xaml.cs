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

namespace z3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox ime;
        private TextBox sifra;

        public TextBox Sifra
        {
            get { return sifra; }
            set { sifra = value;
                Login();
            }
        }

        public TextBox Ime
        {
            get { return ime; }
            set { ime = value;
                Login();
            }
        }
        private void Login()
        {
            ime = new TextBox();
            sifra = new TextBox();
            ime.FontSize = 20;
            ime.Width = 200;
            Canvas.SetTop(ime, 10);
            Canvas.SetLeft(ime, (this.Width - ime.Width) /2);
            ime.Name = "ime";

            sifra.FontSize = 20;
            sifra.Width = 200;
            Canvas.SetTop(sifra, 70);
            Canvas.SetLeft(sifra, (this.Width - ime.Width) / 2);
            sifra.Name = "sifra";

            Button btn = new Button();
            btn.Width = 200;
            btn.FontSize = 20;
            btn.Content = "Prijavi se";
            btn.Background = Brushes.BlueViolet;
            btn.Foreground = Brushes.White;
            Canvas.SetTop(btn, 120);
            Canvas.SetLeft(btn, (this.Width - ime.Width) / 2);

            this.podloga.Children.Add(ime);
            this.podloga.Children.Add(sifra);
            this.podloga.Children.Add(btn);

            this.Background = Brushes.Aqua;

        }

        public MainWindow()
        {
            InitializeComponent();
            Login();
        }
    }
}
