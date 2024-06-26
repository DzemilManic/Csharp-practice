using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba2z2
{
    internal class RedovniLet : Let
    {
        private int brMestaUAvionu;
                
        public int BrMestaUAvionu
        {
            get { return brMestaUAvionu; }
            set { brMestaUAvionu = value; }
        }

        public RedovniLet(string polaznaDestinacija, string dolaznaDestinacija, DateTime datumVremePoletanja, int brRezervisanihMesta, int brMestaUAvionu) : base(polaznaDestinacija, dolaznaDestinacija, datumVremePoletanja, brRezervisanihMesta)
        {
            this.brMestaUAvionu = brMestaUAvionu;
            this.brMestaUAvionu = brMestaUAvionu;
        }

        public override bool Rezervisi()
        {
            if (BrMestaUAvionu > BrRezervisanihMesta)
                return true;
            Console.WriteLine("Nema mesta u avionu");
            return false;
        }
        public override string ToString()
        {
            return $"Na redovnom letu od {PolaznaDestinacija} do {DolaznaDestinacija}"
                + $"koji leti {DatumVremePoletanja} ima {BrRezervisanihMesta}" +
                $"rezervisanih mesta od ukupno {brMestaUAvionu} mesta";
        }
    }
}
