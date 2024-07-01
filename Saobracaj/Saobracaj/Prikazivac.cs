using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class Prikazivac
    {
        public Queue<string> prikazi = new Queue<string>();
        public void DodajNisku(string niska)
        {
            prikazi.Enqueue(niska);
        }
        public void IzbaciNajstarijuNisku()
        {
            if(prikazi.Count > 0)
                prikazi.Dequeue();
        }
        public List<string> DohvatiPrikaze()
        {
            return new List<string>(prikazi);
        }
    }
}
