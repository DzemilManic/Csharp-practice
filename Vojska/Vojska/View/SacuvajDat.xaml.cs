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
using System.Windows.Shapes;

namespace Vojska.View
{
    /// <summary>
    /// Interaction logic for SacuvajDat.xaml
    /// </summary>
    public partial class SacuvajDat : Window
    {
        static public string InputFilePath { get; set; }
        public SacuvajDat()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputFilePath = tbPath.Text;
            DialogResult = true;
        }
    }
}
