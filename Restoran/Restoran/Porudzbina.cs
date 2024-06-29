using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    internal class Porudzbina
    {
		private int brojStola;
		public List<Jelo> PorucenaJela { get; set; }

		public int BrojStola
		{
			get { return brojStola; }
			set { brojStola = value; }
		}
		public Porudzbina(int brS, List<Jelo> poruceno)
		{
			BrojStola = brS;
			PorucenaJela = poruceno;
		}
		public decimal VrednostPorucena()
		{
			return PorucenaJela.Sum(jelo => jelo.Cena);
		}
        public override string ToString()
        {
			string jela = string.Join(",", PorucenaJela.Select(jelo => $"{jelo.Oznaka}:{jelo.Cena}"));
			return $"{brojStola}:{jela}";
        }
    }
}
