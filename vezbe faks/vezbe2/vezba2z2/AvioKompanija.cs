using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba2z2
{
    internal class AvioKompanija
    {
		private Let[] letovi;
		private int brLetova;
		private int maxLetova;

		public int MaxLetova
		{
			get { return maxLetova; }
			set { maxLetova = value; }
		}

		public int BrLetova
		{
			get { return brLetova; }
			set { brLetova = value; }
		}

		public Let[] Letovi
		{
			get { return letovi; }
			set { letovi = value; }
		}
		public AvioKompanija(int maxLetova)
		{
			this.maxLetova = maxLetova;
			this.brLetova = 0;
			letovi = new Let[maxLetova];
		}
		public void DodajLet(Let l)
		{
			if (brLetova == maxLetova)
				return;
			if(l is CharterLet)
			{
				CharterLet temp = l as CharterLet;
				letovi[brLetova++] = new CharterLet(temp.PolaznaDestinacija, temp.DolaznaDestinacija, temp.DatumVremePoletanja, temp.BrRezervisanihMesta, temp.BrMestaRedovnih, temp.BrMestaVanrednih);
			}
			else
			{
				RedovniLet temp = l as RedovniLet;
				letovi[brLetova++] = new RedovniLet(temp.PolaznaDestinacija, temp.DolaznaDestinacija, temp.DatumVremePoletanja, temp.BrRezervisanihMesta, temp.BrMestaUAvionu);
            }

		}
		public void BrisiLet(Let l)
		{
			int index = -1;
			for(int i = 0; i < brLetova; i++)
			{
				if (letovi[i].PolaznaDestinacija == l.PolaznaDestinacija &&
					letovi[i].DolaznaDestinacija == l.DolaznaDestinacija &&
					letovi[i].DatumVremePoletanja == l.DatumVremePoletanja)
				{
					index = i; break;
				}
			}
			if(index > -1)
			{
				for(int i = index; i < brLetova-1; i++)
				{
					letovi[i] = letovi[i +1];
				}
				brLetova--;
			}
		}
		public void RezervisiKartu(string pd, string dd, DateTime dv)
		{
			for(int i = 0;i < brLetova; i++)
			{
				if (letovi[i].PolaznaDestinacija == pd &&
					letovi[i].DolaznaDestinacija == dd &&
					letovi[i].DatumVremePoletanja == dv){
				if (letovi[i].Rezervisi() == true)
					return;
			}
			}
		}
		public override string ToString()
		{
			string s = "Podaci o avio kompaniji" + Environment.NewLine;
			for (int i = 0; i < brLetova; i++)
				s += letovi[i].ToString() + Environment.NewLine;
		}
		public void PoredjajPoVremenu()
		{
			for(int i = 0; i < brLetova ; i++)
		}
	}
}
