using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository repository = new ProductRepository();
            List<Product> products = repository.GetProducts();
            Console.WriteLine($"u nasoj listi imamo {products.Count} elemenata");
            Console.WriteLine($"artikal sa id-jem 2 je {repository.GetProduct(2)}");
            List<Product> cheapProducts = products.FindAll(isCheaper);
            List<Product> cheapProducts2 = products.Where(product => product.Price < 100).ToList();
            Console.WriteLine($"ukupno ima {cheapProducts.Count} jeftinih proizvoda");
           
            Console.ReadLine();
        }
        static bool isCheaper(Product product)
        {
            if (product.Price < 100)
                return true;
            return false;
        }
    }
}
