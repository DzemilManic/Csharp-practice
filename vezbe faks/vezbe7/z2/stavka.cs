using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z2
{
    internal class stavka
    {
        public stavka() {
            Podstavke = new List<stavka>();
        }
        public string Naziv  { get; set; }
        public List<stavka> Podstavke { get; set; }
    }
}
