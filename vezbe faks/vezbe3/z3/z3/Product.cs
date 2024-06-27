using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class Product
    {
		private int id;			

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int price;

		public int Price
		{
			get { return price; }
			set { price = value; }
		}

		private DateTime date;

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

        public override string ToString()
        {
			return $"Id artikla je {Id}" + Environment.NewLine +
				$"naziv artikla je {Name}" + Environment.NewLine +
				$"cena artikla je {Price}" + Environment.NewLine +
				$"datum prodaje artikla je {Date}" + Environment.NewLine;
        }

		

    }
}
