using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product()
            {
                Id = 1,
                Description = "Laptop lenovo p1"
            };
            SMSServer sms = new SMSServer();
            EmailServer email = new EmailServer();
            Order order = new Order();
            order.OrderEvent += sms.OnOrderComplete;
            order.OrderEvent += email.OnOrderComplete;

            order.Process(product);

            Console.ReadLine();
        }
    }
}
