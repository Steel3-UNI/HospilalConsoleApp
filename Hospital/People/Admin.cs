using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public class Admin : Person
{
    public Admin(int id, string name) : base(id, name, string.Empty, string.Empty, string.Empty, RolesEnum.Admin)
    {
        Id = id;
        Name = name;
        Role = RolesEnum.Admin;
        Email = "";
        Phone = "";
    }

    public override void Menu()
    {
        bool cont = true;
        while (cont)
        {
            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List all doctors");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all patients");
            Console.WriteLine("4. Check patient details");
            Console.WriteLine("5. Add doctor");
            Console.WriteLine("6. Add patient");
            Console.WriteLine("7. Exit to Login");
            Console.WriteLine("8. Exit System");

            var input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ListAllDoctors();
                    break;
                case '2':
                    ListByID(1);
                    break;
                case '3':
                    ListAllPatients();
                    break;
                case '4':
                    ListByID(1);
                    break;
                case '5':
                    Add(RolesEnum.Doctor);
                    break;
                case '6':
                    Add(RolesEnum.Patient);
                    break;
                case '7':
                    cont = false;
                    break;
                case '8':
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 8.");
                    break;
            }
        }
        Logout();
    }

    public override void ViewDetails()
    {
        throw new NotSupportedException();
    }

    public void ListAllPatients()
    {
        throw new NotImplementedException();
    }

    public void ListAllDoctors()
    {
        throw new NotImplementedException();
    }

    public void ListByID(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(RolesEnum role)
    {
        throw new NotImplementedException();
    }
}
