using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CHAT.EmployeeManager;

namespace CHAT
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public event MessageEventHandler MessageReceived;
        public virtual void SendMessage(string message)
        {
            Console.WriteLine("");
            OnMessageReceived(FirstName, message);
        }
        protected virtual void OnMessageReceived(string sender, string message)
        {
            MessageReceived?.Invoke(sender, FirstName, message);
        }
    }
}
