using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Krstarenje_jun24
{
    internal class Plovidba
    {
        public AktivanBrod Brod { get; set; }
        public AktivnaLuka Luka1 { get; set; }
        public AktivnaLuka Luka2 { get; set; }

        public Plovidba(string imeBroda, int kapacitetBroda, int kapacitetLuke1, int kapacitetLuke2, Canvas podlogaBrod, Canvas podlogaLuka1, Canvas podlogaLuka2)
        {

            Luka1 = new AktivnaLuka("Luka 1", new Red(kapacitetLuke1));
            Luka1.PodlogaLuka = podlogaLuka1;
            Luka1.PopuniPanel();

            Luka2 = new AktivnaLuka("Luka 2", new Red(kapacitetLuke2));
            Luka2.PodlogaLuka = podlogaLuka2;
            Luka2.PopuniPanel();


            Brod = new AktivanBrod(imeBroda, new Red(kapacitetBroda), Luka1, Luka2);
            Brod.PodlogaBrod = podlogaBrod;
            Brod.PrvaLuka = Luka1;
            Brod.DrugaLuka = Luka2;
            Brod.PopuniPanel();
        }

        public void PokreniPlovidbu()
        {
            Brod.Pokreni();
        }

        public void ZaustaviPlovidbu()
        {
            Brod.Zaustavi();
        }
    }
}
