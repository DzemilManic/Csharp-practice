using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba2z2
{
    internal class CharterLet : Let
    {
        private int brMestaRedovnih;
        private int brMestaVanrednih;
        public int BrMestaRedovnih
        {
            get { return brMestaRedovnih; }
            set { brMestaRedovnih = value; }
        }
        
        public int BrMestaVanrednih
        {
            get { return brMestaVanrednih; }
            set { brMestaVanrednih = value; }
        }


        public CharterLet(string polaznaDestinacija, string dolaznaDestinacija, DateTime datumVremePoletanja, int brRezervisanihMesta, int brMestaRedovnih, int brMestaVanrednih) : base(polaznaDestinacija, dolaznaDestinacija, datumVremePoletanja, brRezervisanihMesta)
        {
            this.brMestaRedovnih = brMestaRedovnih;
            this.brMestaVanrednih = brMestaVanrednih;
        }

        public override bool Rezervisi()
        {
            if (BrRezervisanihMesta < BrMestaRedovnih + BrMestaVanrednih)
            {
                BrRezervisanihMesta++;
                return true;
            }
            else
            {
                Console.WriteLine("Nema mesta u avionu");
                return false;
            }
        }
        public override string ToString()
        {
            return $"Na charter letu od {PolaznaDestinacija} do {DolaznaDestinacija}"
                + $"koji leti {DatumVremePoletanja} ima {BrRezervisanihMesta}" +
                $"rezervisanih mesta od ukupno {BrMestaRedovnih + BrMestaVanrednih} mesta";
        }
    }
}
