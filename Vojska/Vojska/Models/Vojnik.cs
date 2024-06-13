using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vojska.Models
{
	public enum CinEnum{razvodnik, desetar, mladji_vodnik };
    public class Vojnik : INotifyPropertyChanged
    {
		private string ime;
		private string prezime;
		private DateTime datumRodj;
		private CinEnum cin;
		public Vojnik()
		{
			
		}
		public CinEnum Cin
		{
			get { return cin; }
			set { cin = value;
				onPropertyChanged();
			}
		}

		public DateTime DatumRodj
		{
			get { return datumRodj; }
			set { datumRodj = value; }
		}

		public string Prezime
		{
			get { return prezime; }
			set { prezime = value; }
		}

		public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void onPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        }
		public void UnaprediMe()
		{
			if(Cin == CinEnum.razvodnik)
			{
				Cin = CinEnum.desetar;
			}
			else
			{
				MessageBox.Show("Doslo je do greske");
			}
		}
    }
}
