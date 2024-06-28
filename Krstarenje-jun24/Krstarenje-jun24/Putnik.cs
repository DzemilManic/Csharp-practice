using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krstarenje_jun24
{
    internal class Putnik
    {
        private static int sledeciID = 0;
        public int ID { get; set; }

        public Putnik()
        {
            ID = ++sledeciID;
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
