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

namespace z2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var root = new stavka();
            var d1 = new stavka() { Naziv = "Dedo" };
            var b1 = new stavka() { Naziv = "babo" };
            var j1 = new stavka() { Naziv = "ja" };
            var j2 = new stavka(){ Naziv = "brat"};
            var j3 = new stavka() { Naziv = "sestra" };
            b1.Podstavke.Add(j1);
            b1.Podstavke.Add(j2);
            b1.Podstavke.Add(j3);
            var b2 = new stavka() { Naziv = "babov brat" };
            var b3 = new stavka() { Naziv = "babov drugi brat" };
            d1.Podstavke.Add(b1);
            d1.Podstavke.Add(b2);
            d1.Podstavke.Add(b3);
            var d2 = new stavka() { Naziv = "Dedov brat" };
            root.Podstavke.Add(d1);
            root.Podstavke.Add(d2);
            trvStavke.Items.Add(root);
        }
    }
}
