using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restoran
{
    internal class Meni
    {
		private Canvas lista;
		public Jelo[] Jela { get; set; }
		public Canvas Lista
		{
			get { return lista; }
			set { lista = value; }
		}
		public Meni(Canvas lista, Jelo[] jela)
		{
			Jela = jela;
			this.lista = lista;
			PrikaziJela();
		}
		public int ukupnoJela => Jela.Length;
		public Jelo DohvatiPoIndeksu(int ind)
		{
			if(ind < 0 || ind > ukupnoJela)
			{
				throw new IndexOutOfRangeException("Neispravan indeks");
			}
			return Jela[ind];
		}
        private void PrikaziJela()
        {
			Lista.Children.Clear();
			foreach (var v in Jela)
			{
				var textBlock = new TextBlock { Text = v.ToString() };
				Lista.Children.Add(textBlock);
			}
        }
    }
}
