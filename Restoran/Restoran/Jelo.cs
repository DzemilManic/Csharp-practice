using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    internal class Jelo
    {
		private string naziv;
		private int cena;
		private int vreme;

		public int Vreme
		{
			get { return vreme; }
			set { vreme = value; }
		}

		public int Cena
		{
			get { return cena; }
			set { cena = value; }
		}


		public string Naziv
		{
			get { return naziv; }
			set { naziv = value; }
		}
		public Jelo(string n, int c, int v)
		{
			Naziv = n;
			Cena = c;
			Vreme = v;
		}
		public char Oznaka => Naziv[0];
		
		public override string ToString()
		{
			return $"{Naziv} : {Cena}";
		}
	}
}
