using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class Kamera
    {
        public int ID { get; set; }
        public int sledeciID = 1;
        public string poslednjiSnimak;
        public Kamera()
        {
            ID = sledeciID++;
        }
        public void SnimiVozilo(Vozilo vozilo)
        {
            long vreme = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            poslednjiSnimak = $"[{ID}:{vreme}]{vozilo.RegistarskaOznaka}";
        }
        public string DohvatiPoslednjeSnimljeno()
        {
            return poslednjiSnimak;
        }

    }
}
