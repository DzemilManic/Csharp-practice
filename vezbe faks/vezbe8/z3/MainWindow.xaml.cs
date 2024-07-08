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

namespace z3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Studenti { get; set; }
        public Student StudentiZaDodavanje { get; set; }
        public MainWindow()
        {
            Studenti = new ObservableCollection<Student>
            {
                new Student  { Ime = "Merisa", Prezime = "Besirovic", Telefon = "0652312456", GodinaStudija = 2 },
                new Student  { Ime = "Merisa", Prezime = "Besirovic", Telefon = "0652312456", GodinaStudija = 2 },
                new Student  { Ime = "Merisa", Prezime = "Besirovic", Telefon = "0652312456", GodinaStudija = 2 }
            };
            StudentiZaDodavanje = new Student();
            InitializeComponent();
        }
    }
}
