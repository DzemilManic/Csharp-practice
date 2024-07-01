using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class SaobracajnaTraka
    {
        public Queue<Vozilo> vozila = new Queue<Vozilo>();
        public Kamera Kamera;
        public Prikazivac prikazivac;
        public SaobracajnaTraka()
        {
            Kamera = new Kamera();
            prikazivac = new Prikazivac();
        }
        public void DodajVozilo(Vozilo vozilo)
        {
            vozila.Enqueue(vozilo);
            prikazivac.DodajNisku(vozilo.RegistarskaOznaka);
        }
        public void IzbaciVozilo()
        {
            if(vozila.Count > 0)
            {
                Vozilo vozilo = vozila.Dequeue();
                prikazivac.IzbaciNajstarijuNisku();
                Kamera.SnimiVozilo(vozilo);
            }
        }
        public string DohvatiPoslednjiSnimak()
        {
            return Kamera.DohvatiPoslednjeSnimljeno();
        }
    }
}
