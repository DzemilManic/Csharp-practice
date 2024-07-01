using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class Evidencija
    {
        public List<string> evidencija = new List<string>();
        public void DodajSnimak(string snimak)
        {
            evidencija.Add(snimak);
        }
        public void ObrisiEvidenciju()
        {
            evidencija.Clear();
        }
        public List<string> DohvatiEvidenciju()
        {
            return new List<string>(evidencija);
        }
    }
}
