using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restoran
{
	internal class Aktivan_kuvar
	{
		private string ime;
		private Pult pult;
		private Porudzbina trenutnaPorudzbina;
		private bool radi;
		private Thread thread;

		public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}
		public Aktivan_kuvar(string i, Pult pult)
		{
			Ime = i;
			this.pult = pult;
			radi = true;
		}
		public void Radi()
		{
			while (radi)
			{
				try
				{
					trenutnaPorudzbina = pult.UzmiNeplacenu();
					PripremiPorudzbinu();
					pult.NaplatiPorudzbinu(trenutnaPorudzbina);
				}
				catch
				{
					Thread.Sleep(1000);
				}
			}
		}
		private void Stop()
		{
			radi = false;
		}
		private void PripremiPorudzbinu()
		{
			foreach(var jelo in trenutnaPorudzbina.PorucenaJela)
			{
				Thread.Sleep(jelo.Vreme);
			}
		}
	}
}