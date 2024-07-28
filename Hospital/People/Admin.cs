using HospitalConsoleApp.Database;
using HospitalConsoleApp.Output;
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

    HospitalService _service;

    public override void Menu(Database.HospitalService service)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("Administrator Menu");

        _service = service;
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
        _service.DisplayPeople();
    }

    public void ListAllDoctors()
    {
        _service.DisplayPeople();
    }

    public void ListByID(int id)
    {
        _service.GetPersonById(id);
    }

    public void Add(RolesEnum role)
    {
        BaseConsoleCommands.Clear();
        Random rand = new Random();
        string id = rand.Next(40000, 50000).ToString();
        switch (role)
        {
            case RolesEnum.Doctor:
                BaseConsoleCommands.Header("Add Doctor");

                Console.WriteLine("Enter doctor name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter doctor email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter doctor phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter doctor address:");
                string address = Console.ReadLine();

                try 
                {
                    _service.AddPerson(id, name, role, email, phone, address);
                    Console.WriteLine($"{name} added to the system!");
                    Console.WriteLine($"The users system id is: {id}");
                }
                catch(Exception e)
                {
                    Console.WriteLine("One or more of the inputted values is incorrect" + e.Message);
                }
                break;

            case RolesEnum.Patient:
                BaseConsoleCommands.Header("Add Patient");

                Console.WriteLine("Enter patient name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter patient email:");
                email = Console.ReadLine();
                Console.WriteLine("Enter patient phone:");
                phone = Console.ReadLine();
                Console.WriteLine("Enter patient address:");
                address = Console.ReadLine();

                try
                {
                    _service.AddPerson(id, name, role, email, phone, address);
                    Console.WriteLine($"{name} added to the system!");
                    Console.WriteLine($"The users system id is: {id}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("One or more of the inputted values is incorrect" + e.Message);
                }
                break;

            default:
                break;
        }
        Console.ReadLine();
    }
}
