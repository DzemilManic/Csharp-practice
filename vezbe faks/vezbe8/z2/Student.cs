using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace z2
{
    public class Student : INotifyPropertyChanged
    {
		private string ime;
		private string prezime;
		private string telefon;
		private int godinaStudija;

		public int GodinaStudija
		{
			get { return godinaStudija; }
			set { godinaStudija = value;
				OnPropertyChanged();
			}
		}

		public string Telefon
		{
			get { return telefon; }
			set { telefon = value; }
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
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if(PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
