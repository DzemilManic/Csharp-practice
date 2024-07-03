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

namespace z2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string putanjaZaList = "podaciZaList.txt";
        private string putanjaZaCombo = "podaciZaCombo.txt";

        public MainWindow()
        {
            InitializeComponent();
        }
        #region ComboBox
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                DodajStavku();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajStavku();
        }
        private void DodajStavku()
        {
            var text = txtZaCombo.Text;
            text = text.Trim();
            if(string.IsNullOrEmpty(text) )
            {
                return;
            }
            if (cbSadrzaj.Items.Contains(text))
            {
                return;
            }
            cbSadrzaj.Items.Add(text);
            txtZaCombo.Text = string.Empty;
            txtZaCombo.Focus();
            txtBrCombo.Text = cbSadrzaj.Items.Count.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream("podaciZaCombo.txt", FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(fs);
                foreach (var stavka in cbSadrzaj.Items)
                    sw.WriteLine(stavka.ToString());
                sw.Close();
                cbSadrzaj.Items.Clear();
                txtBrCombo.Text = "0";
            }
            catch(Exception ex) 
            {
                    MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream("podaciZaCombo.txt", FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs);
                cbSadrzaj.Items.Clear();
                while(!sr.EndOfStream) 
                {
                    cbSadrzaj.Items.Add(sr.ReadLine());
                    
                }
                txtBrCombo.Text = cbSadrzaj.Items.Count.ToString() ;
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbSadrzaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                var selektovano = cbSadrzaj.SelectedItem as string;
                if (selektovano != null)
                    txtSelCombo.Text = selektovano;
            }
            catch 
            {
                MessageBox.Show("nije nesto dobro");
            }
            
        }
        #endregion
        #region ListBox

        private void txtZaListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                DodajStavkuUListu();
        }

        private void BtnZaList_Click(object sender, RoutedEventArgs e)
        {
            DodajStavkuUListu();
        }
        private void DodajStavkuUListu()
        {
            var text = txtZaList.Text;
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (lbSadrzaj.Items.Contains(text))
            {
                return;
            }
            lbSadrzaj.Items.Add(text);
            txtZaList.Text = string.Empty;
            txtZaList.Focus();
            txtBrList.Text = lbSadrzaj.Items.Count.ToString();
        }

        private void BtnSnimiList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaList, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(fs);
                foreach (var stavka in lbSadrzaj.Items)
                    sw.WriteLine(stavka.ToString());
                sw.Close();
                lbSadrzaj.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUcitajList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaList, FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs);
                lbSadrzaj.Items.Clear();
                while (!sr.EndOfStream)
                {
                    lbSadrzaj.Items.Add(sr.ReadLine());

                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbSadrzaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selektovano = lbSadrzaj.SelectedItem as string;
                if (selektovano != null)
                    txtSelList.Text = selektovano;
            }
            catch
            {
                MessageBox.Show("nije nesto dobro");
            }

        }

        #endregion
    }
}
