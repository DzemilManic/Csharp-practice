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

namespace z3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Student s1 = new Student()
            {
                Ime = "Ilhan",
                Prezime = "Basic",
                prosek = 6.5f
            };
            Student s2 = new Student()
            {
                Ime = "Dzemil",
                Prezime = "Manic",
                prosek = 10.0f
            };
            Student s3 = new Student()
            {
                Ime = "Merisa",
                Prezime = "Besirovic",
                prosek = 9.5f
            };
            Student s4 = new Student()
            {
                Ime = "Hamza",
                Prezime = "Gorecvic",
                prosek = 8.0f
            };
            Student s5 = new Student()
            {
                Ime = "Dzejlana",
                Prezime = "Radoncic",
                prosek = 7.35f
            };
            Student s6 = new Student()
            {
                Ime = "Andrej",
                Prezime = "Rumenic",
                prosek = 6.66f
            };
            Studijski_program si = new Studijski_program() { Naziv = "Softversko inzenjerstvo" };
            Studijski_program rt = new Studijski_program() { Naziv = "Racunarska tehnika" };
            si.Studenti.Add(s1);
            si.Studenti.Add(s2);
            si.Studenti.Add(s3);
            si.Studenti.Add(s4);
            rt.Studenti.Add(s5);
            rt.Studenti.Add(s6);
            List<Studijski_program> programi = new List<Studijski_program>
        }
    }
}
