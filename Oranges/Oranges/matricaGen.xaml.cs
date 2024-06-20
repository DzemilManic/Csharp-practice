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

namespace Oranges
{
    /// <summary>
    /// Interaction logic for matricaGen.xaml
    /// </summary>
    public partial class matricaGen : Window
    {
        private Lista lista;
        public matricaGen()
        {
            InitializeComponent();
        }
        public void Matrica()
        {
            int col = int.Parse(txtKolone.Text);
            int row = int.Parse(txtVrste.Text);
            lista = new Lista(row, col);
        }

    }
}
