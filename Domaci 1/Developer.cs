using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CHAT.EmployeeManager;

namespace CHAT
{
    public class Developer : Employee
    {
        public Developer(int iD, string firstName, string lastName, double salary)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine("Poruka poslata Developeru:");
            Console.WriteLine($"{FirstName} {LastName} (DEV) : {message}");
        }

        public override bool Equals(object obj)
        {
            return obj is Developer developer &&
                   ID == developer.ID &&
                   FirstName == developer.FirstName &&
                   LastName == developer.LastName &&
                   Salary == developer.Salary &&
                   ID == developer.ID &&
                   FirstName == developer.FirstName &&
                   LastName == developer.LastName &&
                   Salary == developer.Salary;
        }
    }
}
