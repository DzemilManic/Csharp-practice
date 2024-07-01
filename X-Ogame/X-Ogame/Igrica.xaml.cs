using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace X_Ogame
{
    /// <summary>
    /// Interaction logic for Igrica.xaml
    /// </summary>
    public partial class Igrica : Window,INotifyPropertyChanged
    {
        Button[,] dugmad;
        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string igrac;
        public string Igrac
        {
            get { return igrac; }
            set { igrac = value; }
        }

        private string racunar;
        public string Racunar
        {
            get { return racunar; }
            set { racunar = value; }
        }

        private int scoreIgrac;
        public int ScoreIgrac
        {
            get { return scoreIgrac; }
            set
            {
                scoreIgrac = value;
                OnPropertyChanged();
            }
        }

        private int scoreRac;
        public int ScoreRac
        {
            get { return scoreRac; }
            set
            {
                scoreRac = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Igrica(string igrac, string ime)
        {
            this.Ime = ime;
            this.Igrac = igrac;
            this.Racunar = (Igrac == "X") ? "O" : "X";
            ScoreIgrac = 0;
            ScoreRac = 0;
            InitializeComponent();
        }
        private void napraviTablu()
        {
            dugmad = new Button[3, 3];
            podloga.Children.Clear();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    dugmad[i, j] = new Button();
                    dugmad[i, j].Height = podloga.ActualHeight / 3;
                    dugmad[i, j].Width = podloga.ActualWidth / 3;
                    dugmad[i, j].Click += Igraj;
                    podloga.Children.Add(dugmad[i, j]);
                }
            }
        }

        private void Igraj(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn != null && btn.Tag.ToString() == "0")
            {
                btn.Content = $"{Igrac}";
                btn.Tag = "1" ;
                if (!jeLiKraj())
                {
                    igraRacunar();
                }
                else
                {
                    napraviTablu();
                }
            }
        }
        private void igraRacunar()
        {
            foreach (var v in dugmad)
            {
                if (v.Tag.ToString() == "0")
                {
                    v.Content = $"{Racunar}";
                    v.Tag = "1";
                    break;
                }
            }
            if (jeLiKraj())
            {
                napraviTablu();
            }
        }
        private bool jeLiKraj()
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (dugmad[i, 0].Content != null &&
                    dugmad[i, 1].Content != null &&
                    dugmad[i, 2].Content != null &&
                    dugmad[i, 0].Content.ToString() == dugmad[i, 1].Content.ToString() &&
                    dugmad[i, 1].Content.ToString() == dugmad[i, 2].Content.ToString() &&
                    dugmad[i, 0].Tag.ToString() == "1")
                {
                    MessageBox.Show($"{dugmad[i, 0].Content} wins!");
                    if (Igrac == dugmad[0, i].Content.ToString())
                    {
                        ScoreIgrac++;
                    }
                    else
                    {
                        ScoreRac++;
                    }
                }
                // Check columns
                if (dugmad[0, i].Content != null &&
                    dugmad[1, i].Content != null &&
                    dugmad[2, i].Content != null &&
                    dugmad[0, i].Content.ToString() == dugmad[1, i].Content.ToString() &&
                    dugmad[1, i].Content.ToString() == dugmad[2, i].Content.ToString() &&
                    dugmad[0, i].Tag.ToString() == "1")
                {
                    MessageBox.Show($"{dugmad[0, i].Content} wins!");
                    if (Igrac == dugmad[0, i].Content.ToString())
                    {
                        ScoreIgrac++;
                    }
                    else
                    {
                        ScoreRac++;
                    }
                    return true;
                }
            }

            // Check diagonals
            if (dugmad[0, 0].Content != null &&
                dugmad[1, 1].Content != null &&
                dugmad[2, 2].Content != null &&
                dugmad[0, 0].Content.ToString() == dugmad[1, 1].Content.ToString() &&
                dugmad[1, 1].Content.ToString() == dugmad[2, 2].Content.ToString() &&
                dugmad[0, 0].Tag.ToString() == "1")
            {
                MessageBox.Show($"{dugmad[0, 0].Content} wins!");
                if (Igrac == dugmad[0, 0].Content.ToString())
                {
                    ScoreIgrac++;
                }
                else
                {
                    ScoreRac++;
                }
            }
            if (dugmad[0, 2].Content != null &&
                dugmad[1, 1].Content != null &&
                dugmad[2, 0].Content != null &&
                dugmad[0, 2].Content.ToString() == dugmad[1, 1].Content.ToString() &&
                dugmad[1, 1].Content.ToString() == dugmad[2, 0].Content.ToString() &&
                dugmad[0, 2].Tag.ToString() == "1")
            {
                MessageBox.Show($"{dugmad[0, 2].Content} wins!");
                if (Igrac == dugmad[0, 2].Content.ToString())
                {
                    ScoreIgrac++;
                }
                else
                {
                    ScoreRac++;
                }
                return true;
            }

            // Check for a tie
            bool tie = true;
            foreach (var v in dugmad)
            {
                if (v.Tag.ToString() == "0")
                {
                    tie = false;
                    break;
                }
            }
            if (tie)
            {
                MessageBox.Show("It's a tie!");
                return true;
            }

            return false;
        }
    }
}
