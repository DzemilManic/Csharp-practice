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

namespace vezbee5z1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool ZatvaranjeDozvoljeno { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cbBoje.Items.Add("crvena");
            cbBoje.Items.Add("zelena");
            cbBoje.Items.Add("plava");
        }

        private void rbZatvaranjeDozvoljeno_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton trenutni = sender as RadioButton;
            if(trenutni.Name == "rbZatvaranjeDozvoljeno")
            {
                txtDogadjaji.Text += "izabrali ste da je zatvaranje dozvoljeno" + Environment.NewLine;
                ZatvaranjeDozvoljeno = true;
            }
            else
            {
                txtDogadjaji.Text += "izabrali ste da zatvaranje nije dozvoljeno" + Environment.NewLine;
                ZatvaranjeDozvoljeno = false;
            }
        }

        private void rbZatvaranjeZabranjeno_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cbBoje_Selected(object sender, RoutedEventArgs e)
        {

            string boja = cbBoje.SelectedItem as string;
            txtDogadjaji.Text += "promenila se boja na " + boja + Environment.NewLine;
            switch(boja)
            {
                case "crvena": this.Background = Brushes.Red; break;
                case "zelena": this.Background = Brushes.Green; break;
                case "plava": this.Background = Brushes.Blue; break;
                default: this.Background = Brushes.White; break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!ZatvaranjeDozvoljeno)
            {
                return;
            }
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtDogadjaji.Text += "pokusaj zatvaranja prozora" + Environment.NewLine;
            if(!ZatvaranjeDozvoljeno)
                e.Cancel = true;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            txtDogadjaji.Text += "pomerio se kursor na poziciju (" + e.GetPosition(this).X + "," +
                e.GetPosition(this).Y + ")" + Environment.NewLine;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtDogadjaji.Text += "prozor se otvorio" + Environment.NewLine;
       
        }
    }
}
