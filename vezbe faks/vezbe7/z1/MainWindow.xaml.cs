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
using System.Diagnostics;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PretragaPutanje();
        }
        private void PretragaPutanje()
        {
            try
            {
                string putanja = txtPutanja.Text;
                var di = new DirectoryInfo(txtPutanja.Text);
                lbFolderi.Items.Clear();
                foreach (var folder in di.GetFiles())
                {
                    lbFolderi.Items.Add(folder.Name);
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }

        }
        private void lbFolderi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var naziv = lbFolderi.SelectedItem as string;
                string putanja = (txtPutanja.Text.EndsWith("/") ? txtPutanja.Text : txtPutanja + "/") + naziv;
                var di = new DirectoryInfo(putanja);
                lbFajlovi.Items.Clear();
                foreach(var fajl in di.GetFiles()){
                    lbFajlovi.Items.Add(fajl.Name);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbFolderi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var naziv = lbFolderi.SelectedItem as string;
                string putanja = (txtPutanja.Text.EndsWith("/") ? txtPutanja.Text : txtPutanja + "/") + naziv;
                txtPutanja.Text = putanja;
                PretragaPutanje();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbFajlovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var folder = lbFolderi.SelectedItem as string;
                var fajl = lbFajlovi.SelectedItem as string;
                var putanja = (txtPutanja.Text.EndsWith("/") ? txtPutanja.Text : txtPutanja + "/") +
                    folder + "/" + fajl;
                Process.Start(putanja);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
