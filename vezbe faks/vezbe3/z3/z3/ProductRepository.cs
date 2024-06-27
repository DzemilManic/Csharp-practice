using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class ProductRepository
    {
        public static List<Product> products;
        public ProductRepository() {
            products = new List<Product>();
            products.Add(new Product
            {
                Id = 1,
                Name = "Hleb",
                Price = 80,
                Date = new DateTime(2024,3,10)
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Milka",
                Price = 120,
                Date = new DateTime(2024, 3, 10)
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Jogurt",
                Price = 100,
                Date = new DateTime(2024, 3, 10)
            });

        }
        public List<Product> GetProducts()
        {
            return products; 
        }
        public Product GetProduct(int id)
        {
            Product p = products.Find(x => x.Id == id);
            if (p == null)
                throw new Exception("neispravan id");
            return p;
        }
    }
}
