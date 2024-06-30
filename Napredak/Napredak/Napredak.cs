using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napredak
{
    internal class Napredak
    {
        private Indikator_napretka indikator;

        public Napredak(Indikator_napretka indikator)
        {
            this.indikator = indikator;
        }

        public void PrijaviSe(Aktivan_posao posao)
        {
            //posao.ObavestivaStvar = indikator;
        }
    }
}
