using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace z1.View
{
    /// <summary>
    /// Interaction logic for pageVlasnik.xaml
    /// </summary>
    public partial class pageVlasnik : Page
    {
        public VLASNIK NoviVlasnik { get; set; } = new VLASNIK();
        public ObservableCollection<VLASNIK> Vlasnici { get; set; }
        public Parking_servisEntities context { get; set; } = new Parking_servisEntities();
        public pageVlasnik()
        {
            ucitavanjeVlasnika();
            InitializeComponent();
        }
        private void ucitavanjeVlasnika()
        {
            Vlasnici = new ObservableCollection<VLASNIK>();
            var vl = context.VLASNIKs.ToList();
            foreach (var v in vl)
            {
                Vlasnici.Add(v);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.VLASNIKs.Add(NoviVlasnik);
            context.SaveChanges();
        }
    }
}
