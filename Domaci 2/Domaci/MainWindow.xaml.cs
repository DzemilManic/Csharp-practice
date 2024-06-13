using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Domaci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ulazniPodaci = "ulazniPodaci.txt";
        private string izlazniPodaci = "izlazniPodaci.txt";
        public struct Taxi
        {
            public string nazivTaksija { get; set; }
            public string vrstaVozila { get; set; }
            public double cenaPoKm { get; set; }
            public string zauzetost { get; set; }
            public Taxi(string nt, string vv, double cpk, string z)
            {
                nazivTaksija = nt;
                vrstaVozila = vv;
                cenaPoKm = cpk;
                zauzetost = z;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            pocetnaDat();
        }
        void pocetnaDat()
        {
            try
            {
                FileStream fs = new FileStream(ulazniPodaci, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Random random = new Random();
                
                string[] NazivTaksija = { "Maxi", "Pink", "Uber", "Tahi", "Akica", "Beko" };
                string[] VrstaVozila = { "Limuzina", "Karavan" };
                double[] CenaPoKm = { 90, 95, 97, 105, 122, 140 };
                string[] Zauzetost = { "+", "-"};

                for(int i = 0; i < NazivTaksija.Length; i++)
                {
                    string nazivT = NazivTaksija[i];
                    string vrstaV = VrstaVozila[random.Next(VrstaVozila.Length)];
                    double cenaKm = CenaPoKm[i];
                    string zauzeto = Zauzetost[random.Next(Zauzetost.Length)];
                    sw.WriteLine($"{nazivT}, {vrstaV}, {cenaKm}, {zauzeto}");
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Neuspesno otvaranje datoteke, {e.Message}");
            }
        }
        
        private void ucitajPodatke(string VrstaV)
        {
            FileStream fs1 = new FileStream(ulazniPodaci, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs1);

            FileStream fs2 = new FileStream(izlazniPodaci, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
        
            while (!sr.EndOfStream)
            {
                string linija = sr.ReadLine();
                string[] podaci = linija.Split(',');
                if (podaci.Length > 0)
                {
                    string zauzet = podaci[3] == "+" ? "Slobodan" : "Zauzet";
                    if (VrstaV == podaci[1])
                    {
                        sw.WriteLine($"{podaci[1]}, {podaci[0]}, {podaci[2]}, {zauzet}");
                    }
                }
            }
            sw.Close();
            fs2.Close();
            sr.Close();
            fs1.Close();
            ispisIzDatoteke();
        }
        private void ispisIzDatoteke()
        {
            FileStream fs = new FileStream(izlazniPodaci, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGrid.Items.Clear();

            while (!sr.EndOfStream)
            {
                string linija = sr.ReadLine();
                string[] podaci = linija.Split(',');
                double cena = double.Parse(podaci[2]);  //mora parse jer se ucitavaju kao string
                Taxi novi = new Taxi(podaci[0], podaci[1], cena, podaci[3]);
                dodajUGrid(novi);
            }
            fs.Close();
            sr.Close();
        }
        void dodajUGrid(Taxi taxi)
        {
            dataGrid.Items.Add(taxi);
        }
        private string najviseKm()
        {
            var najjeftiniji = dataGrid.Items.Cast<Taxi>().OrderBy(taxi => taxi.cenaPoKm).First();
            int Novac;
            if(int.TryParse(novac.Text, out Novac))
            {
                return $"Najvise kilometara cete preci sa '{najjeftiniji.nazivTaksija}' " +
                    $"taksijem, i to {Novac / najjeftiniji.cenaPoKm} kilometara.";
            }
            else if(Novac < najjeftiniji.cenaPoKm)
            {
                MessageBox.Show("Sa unetim novcem ne mozete platiti niti jedan taxi");
                novac.Focus();
                return "";
            }
            else
            {
                MessageBox.Show("Neispravan unos");
                novac.Focus();
                return "";
            }
        }
        private string zaradaKompanije()
        {
            if (dataGrid.Items.Count > 0)
            {
                double zarada = 0;
                foreach (Taxi item in dataGrid.Items)
                {
                    if (item.zauzetost.Trim() == "Zauzet")
                        zarada += item.cenaPoKm * 0.1;
                }
                return $"Od zauzetih taksija kompanija ce ukupno zaraditi {zarada}";
            }
            else
                return $"Kompanija nece zaraditi nista, jer nema vozila";
        }
        private string slobodni()
        {
            if (dataGrid.Items.Count > 0)
            {
                int Slobodni = 0;
                foreach (Taxi item in dataGrid.Items)
                {
                    if (item.zauzetost.Trim() == "Slobodan")
                        Slobodni++;
                }
                return $"Slobodnih taksija ima {Slobodni}";
            }
            else
                return $"Kompanija nema vozila";
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem izabrano = (ComboBoxItem)ComboBox.SelectedItem;
            string Izabrano = izabrano.Content.ToString();
            ucitajPodatke(Izabrano);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists(izlazniPodaci))
            {
                Process.Start(izlazniPodaci);
            }
            else
            {
                MessageBox.Show("Fajl ne postoji");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(izlazniPodaci, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string najvise = najviseKm();
                        string Zarada = zaradaKompanije();
                        string Slobodni = slobodni();
                        sloobodni.Text = Slobodni;
                        km.Text = najvise;
                        zarada.Text = Zarada;
                        sw.WriteLine(km);
                        sw.WriteLine(zarada);
                        sw.WriteLine(sloobodni);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska, {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(ulazniPodaci))
            {
                Process.Start(ulazniPodaci);
            }
            else
            {
                MessageBox.Show("Fajl ne postoji");
            }
        }
    }
}
