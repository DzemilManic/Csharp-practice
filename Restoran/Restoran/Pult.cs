using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    internal class Pult
    {
        public decimal Zarada { get; set; }
        private List<Porudzbina> neplacenePorudzbine;
        private List<Porudzbina> placenePorudzbine;
        public IReadOnlyList<Porudzbina> NeplacenePorudzbine => neplacenePorudzbine;
        public IReadOnlyList<Porudzbina> PlacenePorudzbine => placenePorudzbine;
        public Pult()
        {
            Zarada = 0;
            neplacenePorudzbine = new List<Porudzbina>();
            placenePorudzbine = new List<Porudzbina>();
        }
        public void DodajPorudzbinu(Porudzbina p)
        {
            neplacenePorudzbine.Add(p);
        }
        public void NaplatiPorudzbinu(Porudzbina p)
        {
            Zarada += p.VrednostPorucena();
            neplacenePorudzbine.Remove(p);
            placenePorudzbine.Add(p);
        }
        public Porudzbina UzmiNeplacenu()
        {
            if(neplacenePorudzbine.Count == 0)
            {
                throw new Exception("nema neplacenih");
            }
            return neplacenePorudzbine[0];
        }

    }
}
