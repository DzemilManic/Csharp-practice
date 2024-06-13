using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Vojska.Models;

namespace Vojska.View
{
    /// <summary>
    /// Interaction logic for ListaVojnici.xaml
    /// </summary>
    public partial class ListaVojnici : UserControl
    {
        public ObservableCollection<Vojnik> Vojnici { get; set; }
        public delegate void UnaprediVojnika();

        public event UnaprediVojnika unapredivojnika;
        public ListaVojnici(Vod vod)
        {
            Vojnici = vod.listaVojnika;
            DataContext = this;
            InitializeComponent();
            lvVojnici.ItemsSource = vod.listaVojnika;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in Vojnici)
            {
                unapredivojnika += item.UnaprediMe;
            }
            unapredivojnika();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sortirani = new ObservableCollection<Vojnik>(Vojnici.OrderBy((vojnik => vojnik.DatumRodj)));
            Vojnici.Clear();
            foreach(var item in sortirani)
            {
                Vojnici.Add(item);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SacuvajDat sacuvaj = new SacuvajDat();
            sacuvaj.ShowDialog();
            if (sacuvaj.DialogResult == true)
            {
                string path = SacuvajDat.InputFilePath;

                string Buffer = "";
                foreach (var item in Vojnici)
                {
                    Buffer += item.Ime;


                }
                try
                {
                    File.WriteAllText(path, Buffer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (File.Exists(path))
                {
                    sacuvaj.Close();
                    MessageBox.Show("Uspesno ste uneli");
                }
                else
                {
                    MessageBox.Show("doslo je do gresek prilikom kreiranja fajla");
                }


            }
        }
    }
}
