using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    internal class Ulica : Saobracajnica
    {
        public Ulica(int brT, int tmin = 100, int tmax = 1000) : base (brT, tmin, tmax)
        {

        }
        public void DodajVoziloNaUlicu()
        {
            Vozilo vozilo = new Vozilo();
            int indeksTrake = random.Next(trake.Count);
            trake[indeksTrake].DodajVozilo(vozilo);
        }
        public string UzmiVozilo()
        {
            int indeksTrake = random.Next(trake.Count);
            string registracija = trake[indeksTrake].IzbaciVozilo();
            if( registracija != null )
            {
                return trake[indeksTrake].DohvatiPoslednjiSnimak();
            }
            return null;
        }
    }
}
