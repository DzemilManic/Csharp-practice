using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace z5
{
    internal class Order
    {
        public delegate void OrderHandler(Object sender, EventArgs args);
        public event OrderHandler OrderEvent;
        public void Process(Product product)
        {
            Console.WriteLine($"prodali smo product {product.Id}");
            Thread.Sleep(3000);

            OnOrderComplete();

        }
         public void OnOrderComplete()
        {
            if(OrderEvent != null)
            {
                OrderEvent(this, EventArgs.Empty);
            }
        }
    }
}
