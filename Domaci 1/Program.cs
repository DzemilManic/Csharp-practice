using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CHAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1. Unos, izmena i brisanje podataka o programerima,");
                Console.WriteLine("2. Slanje poruka,");
                Console.WriteLine("0. Izlaz.");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ManageEmployees(employeeManager);
                        break;
                    case 2:
                        SendMessage();
                        break;
                    case 0:
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("Izabrali ste opciju koja ne postoji, molimo izaberite jednu od navedenih.");
                        break;
                }
            }

        }

        static void ManageEmployees(EmployeeManager employeeManager)
        {
            bool manageEmployees = true;
            while (manageEmployees)
            {
                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1. Unos novog Developera,");
                Console.WriteLine("2. Izmena Developera,");
                Console.WriteLine("3. Brisanje Developera,");
                Console.WriteLine("4. Unos novog QA,");
                Console.WriteLine("5. Izmena QA,");
                Console.WriteLine("6. Brisanje QA,");
                Console.WriteLine("0. Nazad.");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddDeveloper(employeeManager);
                        break;
                    case 2:
                        EditDeveloper(employeeManager);
                        break;
                    case 3:
                        DeleteDeveloper(employeeManager);
                        break;
                    case 4:
                        AddQA(employeeManager);
                        break;
                    case 5:
                        EditQA(employeeManager);
                        break;
                    case 6:
                        DeleteQA(employeeManager);
                        break;
                    case 0:
                        manageEmployees = false;
                        break;
                    default:
                        Console.WriteLine("Izabrali ste opciju koja ne postoji, molimo izaberite jednu od navedenih.");
                        break;
                }
            }
        }

        static void AddDeveloper(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID Developera:");
            int iD;
            if (!int.TryParse(Console.ReadLine(), out iD))
            {
                Console.WriteLine("Neispravan ID, pokušajte ponovo.");
                return;
            }
            Console.WriteLine("Unesite ime Developera:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Unesite prezime Developera:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Unesite platu Developera:");
            double salary = double.Parse(Console.ReadLine());

            employeeManager.AddDeveloper(iD, firstName, lastName, salary);
        }

        static void EditDeveloper(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID Developera za izmenu:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novo ime Developera:");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Unesite novo prezime Developera:");
            string newLastName = Console.ReadLine();
            Console.WriteLine("Unesite novu platu Developera:");
            double newSalary = double.Parse(Console.ReadLine());

            employeeManager.EditDeveloper(id, newFirstName, newLastName, newSalary);
        }

        static void DeleteDeveloper(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID Developera za brisanje:");
            int id = int.Parse(Console.ReadLine());
            employeeManager.DeleteDeveloper(id);
        }

        static void AddQA(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID QA:");
            int iD;
            if (!int.TryParse(Console.ReadLine(), out iD))
            {
                Console.WriteLine("Neispravan ID, pokušajte ponovo.");
                return;
            }
            Console.WriteLine("Unesite ime QA:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Unesite prezime QA:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Unesite platu QA:");
            double salary = double.Parse(Console.ReadLine());

            employeeManager.AddQA(iD, firstName, lastName, salary);
        }

        static void EditQA(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID QA za izmenu:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novo ime QA:");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Unesite novo prezime QA:");
            string newLastName = Console.ReadLine();
            Console.WriteLine("Unesite novu platu QA:");
            double newSalary = double.Parse(Console.ReadLine());

            employeeManager.EditQA(id, newFirstName, newLastName, newSalary);
        }

        static void DeleteQA(EmployeeManager employeeManager)
        {
            Console.WriteLine("Unesite ID QA za brisanje:");
            int id = int.Parse(Console.ReadLine());
            employeeManager.DeleteQA(id);
        }

        static void SendMessage()
        {
            Console.WriteLine("Unesite ID zaposlenog:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Neispravan ID, pokušajte ponovo.");
                return;
            }

            Console.WriteLine("Unesite tekst poruke:");
            string message = Console.ReadLine();

            Employee recipient = null;
            bool isDeveloper = false;
            bool isQA = false;

            foreach (Developer dev in EmployeeManager.GetDevelopers())
            {
                if (dev.ID == id)
                {
                    recipient = dev;
                    isDeveloper = true;
                    break;
                }
            }

            if (!isDeveloper)
            {
                foreach (QA qa in EmployeeManager.GetQAs())
                {
                    if (qa.ID == id)
                    {
                        recipient = qa;
                        isQA = true;
                        break;
                    }
                }
            }

            if (recipient != null)
            {
                if (message.StartsWith("feature/"))
                {
                    foreach (Developer dev in EmployeeManager.GetDevelopers())
                    {
                        dev.SendMessage($"{recipient.FirstName} {recipient.LastName}: {message}");
                    }
                }
                else if (message.StartsWith("testing/"))
                {
                    foreach (QA qa in EmployeeManager.GetQAs())
                    {
                        qa.SendMessage($"{recipient.FirstName} {recipient.LastName}: {message}");
                    }
                }
                else
                {
                    foreach (Developer dev in EmployeeManager.GetDevelopers())
                    {
                        dev.SendMessage($"{recipient.FirstName} {recipient.LastName}: {message}");
                    }
                    foreach (QA qa in EmployeeManager.GetQAs())
                    {
                        qa.SendMessage($"{recipient.FirstName} {recipient.LastName}: {message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nepostojeći ID zaposlenog.");
            }
        }


    }
}
