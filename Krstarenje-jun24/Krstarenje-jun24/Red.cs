using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Krstarenje_jun24
{
    internal class Red : INotifyPropertyChanged
    {
        private Queue<Putnik> redPutnika;
        private int brPutnika;
        private TextBlock opis;

        public TextBlock Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public int BrPutnika
        {
            get { return brPutnika; }
            set { brPutnika = value; }
        }

        public Queue<Putnik> RedPutnika
        {
            get { return redPutnika; }
            set
            {
                redPutnika = value;
                OnPropertyChanged();
                OsveziPrikaz();
            }
        }



        public Red(int brojPutnika)
        {
            BrPutnika = brojPutnika;
            RedPutnika = new Queue<Putnik>(BrPutnika);
            Opis = new TextBlock();
            OsveziPrikaz();
        }
        public void StaviPutnika(Putnik p)
        {
            if (jeLiPun())
            {
                throw new ThreadInterruptedException("Red je pun");
            }
            RedPutnika.Enqueue(p);
            OsveziPrikaz();
        }
        public Putnik UzmiPutnika()
        {
            if (jeLiPrazan())
            {
                throw new ThreadInterruptedException("Red je prazan");
            }
            var putnik = RedPutnika.Dequeue();
            OsveziPrikaz();
            return putnik;
        }
        public void IsprazniRed()
        {
            RedPutnika.Clear();
            OsveziPrikaz();
        }
        public int BrojPutnika()
        {
            return RedPutnika.Count();
        }

        public bool jeLiPun()
        {
            return BrojPutnika() >= BrPutnika;
        }
        public bool jeLiPrazan()
        {
            return BrojPutnika() == 0;
        }
        public override string ToString()
        {
            var txt = new StringBuilder();
            foreach (var v in RedPutnika)
            {
                txt.Append(v.ToString());
            }
            return txt.ToString();
        }

        private void OsveziPrikaz()
        {
            //Opis.Text = ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
