using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT
{
    public class EmployeeManager
    {
        private static List <Developer> developers = new List<Developer>();
        private static List <QA> qas = new List <QA>();

        public delegate void MessageEventHandler(string sender, string recipient, string message);

        public static List <Developer> GetDevelopers()
        {
            return developers;
        }
        public static List <QA> GetQAs()
        {
            return qas;
        }

        public void AddDeveloper(int iD,string firstName, string lastName, double salary)
        {
            Developer developer = new Developer(iD, firstName, lastName, salary);
            developers.Add(developer);
        }

        public void EditDeveloper(int id, string newFirstName, string newLastName, double newSalary)
        {
            Developer developer = developers.Find(dev => dev.ID == id);
            if (developer != null)
            {
                developer.FirstName = newFirstName;
                developer.LastName = newLastName;
                developer.Salary = newSalary;
            }
            else
            {
                Console.WriteLine("Developer sa unetim ID-jem ne postoji.");
            }
        }

        public void DeleteDeveloper(int id)
        {
            Developer developer = developers.Find(dev => dev.ID == id);
            if (developer != null)
            {
                developers.Remove(developer);
                Console.WriteLine("Developer izbrisan.");
            }
            else
            {
                Console.WriteLine("Developer sa unetim ID-jem ne postoji.");
            }
        }

        public void AddQA(int iD, string firstName, string lastName, double salary)
        {
            QA qa = new QA(iD, firstName, lastName, salary);
            qas.Add(qa);
        }

        public void EditQA(int id, string newFirstName, string newLastName, double newSalary)
        {
            QA qa = qas.Find(q => q.ID == id);
            if (qa != null)
            {
                qa.FirstName = newFirstName;
                qa.LastName = newLastName;
                qa.Salary = newSalary;
            }
            else
            {
                Console.WriteLine("QA sa unetim ID-jem ne postoji.");
            }
        }

        public void DeleteQA(int id)
        {
            QA qa = qas.Find(q => q.ID == id);
            if (qa != null)
            {
                qas.Remove(qa);
                Console.WriteLine("QA izbrisan.");
            }
            else
            {
                Console.WriteLine("QA sa unetim ID-jem ne postoji.");
            }
        }
    }
}
