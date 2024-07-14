using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace z1.View
{
    /// <summary>
    /// Interaction logic for pageCenovnik.xaml
    /// </summary>
    public partial class pageCenovnik : Page
    {
        Parking_servisEntities content = new Parking_servisEntities();
        public CENOVNIK  Cenovnik { get; set; }
        public pageCenovnik()
        {
            Cenovnik = content.CENOVNIKs.FirstOrDefault();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = context.SaveChanges();
            if(result > 0 ) {
                MessageBox.Show("uspesno sacuvana izmena");
            }
        }
    }
}
