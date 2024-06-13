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
using Vojska.Models;

namespace Vojska.View
{
    /// <summary>
    /// Interaction logic for DodajVojnika.xaml
    /// </summary>
    public partial class DodajVojnika : UserControl
    {
        Vod vod;
        public DodajVojnika(Vod vod)
        {
            InitializeComponent();
            this.vod = vod;
            this.DataContext = this.vod;
        }

        private void dodajVojnika_Click(object sender, RoutedEventArgs e)
        {
            Vojnik noviVojnik = new Vojnik();
            noviVojnik.Ime = txtIme.Text;
            noviVojnik.Prezime = txtPrezime.Text;
            try
            {
                DateTime datum = DateTime.Parse(txtDatum.Text);
                noviVojnik.DatumRodj = datum;
                noviVojnik.Cin = (CinEnum)cbCin.SelectedIndex;
                vod.listaVojnika.Add(noviVojnik);
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
