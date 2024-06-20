using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oranges
{
    internal class Lista
    {
        public Narandze[,] matrica;
        public event Action<Narandze> pokvarena;
        public Lista(int row, int col) { 
            matrica = new Narandze[row, col]; ;

        }
    }
}
