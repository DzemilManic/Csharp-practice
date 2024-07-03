using System;
using System.Collections.Generic;
using System.IO;
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

namespace z1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Snimi()
        {
            try { 
                FileStream fs = new FileStream("podaci.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach(var stavka in lbStavke.Items)
                {
                    sw.WriteLine(stavka.ToString());
                }
                sw.Close();
                lbStavke.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Ucitaj()
        {
            try
            {
                FileStream fs = new FileStream("podaci.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                lbStavke.Items.Clear ();
                while(!sr.EndOfStream)
                {
                    var stavka = sr.ReadLine();
                    lbStavke.Items.Add(stavka);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeStavke();
        }

        private void DodavanjeStavke()
        {
            var text = txtSadrzaj.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("niste uneli tekst");
                return;
            }
            if (lbStavke.Items.Contains(text))
            {
                MessageBox.Show("stavka vec postoji u listboxu");
                return;
            }
            lbStavke.Items.Add(text);
            txtSadrzaj.Text = string.Empty;
            txtSadrzaj.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lbStavke.Items.Count > 0 && MessageBox.Show(@"listbox nije prazam, da li 
                   zelite da obrisete", "potvrda", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                Ucitaj();
            }
         
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Snimi();
        }

        private void txtSadrzaj_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) {
                DodavanjeStavke();
            }
        }
    }
}
