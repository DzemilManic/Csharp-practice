using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace vezbe5z2
{
    public class Opstina
    {
        public int PostBroj { get; set; }  
        public string Naziv { get; set; }
        public int BrojStan { get; set; }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Opstina> opstine = new List<Opstina>();
        public MainWindow()
        {
            InitializeComponent();
            btnDa.Visibility = Visibility.Hidden;
            btnNe.Visibility = Visibility.Hidden;
        }
        private float izracunajProsek()
        {
            float s = 0;
            for(int i =  0; i < LvOpstine.Items.Count; i++)
            {
                s += opstine[i].BrojStan;
                s += (LvOpstine.Items[i] as Opstina).BrojStan;
            }
            if(LvOpstine.Items.Count > 0)
            {
                float prosek = s / LvOpstine.Items.Count;
                return prosek;
            }
            return 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int postBroj, brojStan;
            if (string.IsNullOrEmpty(txtPB.Text) || !int.TryParse(txtPB.Text, out int pb))
            {
                MessageBox.Show("Postanski broj nije unet ili je unet kao neipravan broj");
                return;
            }
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                MessageBox.Show("Naziv nije unet");
                return;
            }
            if (string.IsNullOrEmpty(txtBrojStan.Text) || !int.TryParse(txtBrojStan.Text, out int bs))
            {
                MessageBox.Show("Broj stanovnika nije unet");
                return;
            }
            Opstina opstina = opstine.FirstOrDefault(x => x.PostBroj == pb);
            
            Opstina o = new Opstina
            {
                Naziv = txtNaziv.Text,
                PostBroj = pb,
                BrojStan = bs
            };
            
            opstine.Add(o);
            LvOpstine.ItemsSource = null;
            LvOpstine.ItemsSource = opstine;
            float p = izracunajProsek();
            txtProsek.Text = p.ToString();
            txtNaziv.Text = string.Empty;
            txtBrojStan.Text = "";
            txtPB.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btnDa.Visibility = Visibility.Visible;
            btnNe.Visibility = Visibility.Visible;
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            int index = LvOpstine.SelectedIndex;
            if (index > -1)
            {
                Opstina opstinaZaBrisanje = opstine[index];
                opstine.Remove(opstinaZaBrisanje);
                LvOpstine.ItemsSource = null;
                LvOpstine.ItemsSource = opstine;
                float p = izracunajProsek();
                txtProsek.Text = p.ToString();
            }
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            btnDa.Visibility= Visibility.Hidden;
            btnNe.Visibility= Visibility.Hidden;
        }
    }
}
