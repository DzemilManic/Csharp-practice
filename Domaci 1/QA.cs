using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CHAT.EmployeeManager;

namespace CHAT
{
    public class QA : Employee
    { 
        public QA(int iD, string firstName, string lastName, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            ID = iD;
        }
        public override void SendMessage(string message)
        {
            Console.WriteLine("Poruka poslata QA:");
            Console.WriteLine($"{FirstName} {LastName} (QA) : {message}");
        }
    }
}
