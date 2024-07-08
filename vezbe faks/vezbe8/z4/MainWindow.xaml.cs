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

namespace z4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DB db;
        public ObservableCollection<Person> Persons { get; set; }
        public MainWindow()
        {
            db = new DB();
            pokupiPodatke();
            InitializeComponent();
        }
        private void pokupiPodatke()
        {
            var dt = db.GetAll();
            foreach (var item in dt.Rows) {
                Persons.Add(
                    new Person
                    {
                        FirstName = item[0].ToString(),
                    });
            }
        }
    }
}
