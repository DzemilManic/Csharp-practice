using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private int _cols;
        private int _rows;
        private Button[,] dugmici;

        public int Rows
        {
            get { return _rows; }
            set { _rows = value;
                PodesiDugmice();
            }
           
        }

        public int Cols
        {
            get { return _cols; }
            set { _cols = value;
            PodesiDugmice();
        }
            
        }
    

        public MainWindow()
        {
            InitializeComponent();
            Cols = 8;
            Rows = 8;
        }
        private void PodesiDugmice()
        {
            dugmici = new Button[_rows, _cols];
            int i, j;
            for(i = 0; i < _rows; i++)
                for(j = 0; j < _cols; j++)
            {
                dugmici[i, j] = new Button();
                var sirina = this.Width / _cols;
                var visina = this.Height / _rows;
                dugmici[i, j].Width = sirina;
                dugmici[i, j].Height = visina;
                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                    {
                        dugmici[i, j].Background = Brushes.White;
                        dugmici[i, j].Foreground = Brushes.Black;
                    }
                dugmici[i,j].Content = $"{ (char)(72 - i)}{j + 1}";
                
                Canvas.SetTop(dugmici[i, j], i * 50);
                Canvas.SetLeft(dugmici[i, j], j * 100);

                this.podloga.Children.Add(dugmici[i, j]);
            }
        }
        private void dugme_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Content.ToString());
        }
        
    }
}
