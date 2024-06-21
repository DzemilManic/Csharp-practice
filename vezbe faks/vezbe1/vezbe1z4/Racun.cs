using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe1z4
{
    public class Racun
    {
        //polja
        private string imeiprezime;
        private float stanje;
        private string brRacuna;
        private int brTransakcija;
        //svojstva
        public string ImeiPrezime
        {
            set {
                imeiprezime = value;
            }
            get {
                return imeiprezime;
            }
        }
        public float Stanje
        {
            get { return stanje; }

        }
        public string BrRacuna
        {
            get { return BrRacuna; }
        }
        public int BrTransakcija
        {
            get { return BrTransakcija; }
        }
        public Racun(string ip, float s, string br)
        {
            imeiprezime = ip;
            stanje = s;
            brRacuna = br;
        }
        //ctor + tab tab za konstruktor
        public void uvecanje(float u)
        {
            stanje += u;
        }
        public void umanjenje(float u)
        {

            if (stanje < u)
            {
                Console.WriteLine("nije moguce umanjiti stanje jer nema dovoljno novca");
                return;
            }            
            stanje -= u;
        }
        public void prebacaj(Racun r, float iznos)
        {
            if(r.Stanje > iznos)
            {
                r.umanjenje(iznos);
                this.uvecanje(iznos);
                r.brTransakcija++;
                this.brTransakcija++;
            }
            else
            {
                Console.WriteLine("nemate dovoljno novca za prenos");
            }
        }
        public override string ToString()
        {
            return "Vlasnik racuna " + brRacuna + " je " + imeiprezime + " i on ima na racunu " + stanje + " a odradio je transakcija" + brTransakcija;
        }


    }
}
