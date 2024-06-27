using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z5
{
    public class SMSServer
    {
        public void OnOrderComplete(Object sender, EventArgs args)
        {
            Console.WriteLine("SMS: Pristigla je nova porudzbina za artikal");
        }
    }
    public class EmailServer
    {
        public void OnOrderComplete(Object sender, EventArgs args)
        {
            Console.WriteLine("E-MAIL: Pristigla je nova porudzbina za artikal");
        }
    }
}
