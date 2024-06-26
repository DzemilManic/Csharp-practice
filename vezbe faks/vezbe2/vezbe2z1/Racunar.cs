using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe2z1
{
    internal class Racunar
    {
        //propfull za polje i svojstvo ujedno
        private int broj;
        private Random r = new Random();
        public int Broj
        {
            get { return broj; }
            set { broj = value; }
        }
        public void GetBroj()
        {
            Broj = r.Next(1, 10);
        }
        public Racunar()
        {
            Broj = r.Next(1, 10);
        }
    }
}
