using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe3z1
{
    public class slika
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		public slika()
		{
			title = "Nature";
		}
		public static slika Load(string url) // static, ne mora instanca da bi se pristupilo
		{
			return new slika();
		}
		public void Save()
		{
			Console.WriteLine("snimljene su nove promene na slici");
		}

	}
}
