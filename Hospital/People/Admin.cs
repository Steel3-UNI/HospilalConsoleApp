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
    public Admin(int id, string name, string password) : base(id, name, string.Empty, string.Empty, string.Empty, RolesEnum.Admin, password)
    {
        Id = id;
        Name = name;
        Role = RolesEnum.Admin;
        Email = "";
        Phone = "";
        Password = password;
    }

    HospitalService _service;

    public override void Menu(HospitalService service)
    {
        _service = service;
        bool cont = true;
        while (cont)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Administrator Menu");

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
                    ListByID();
                    break;
                case '3':
                    ListAllPatients();
                    break;
                case '4':
                    ListByID();
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
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("All Patients");
        Console.WriteLine($"\nAll patients registered to the DOTNET Hospital Management System:\n");
        Console.WriteLine("Patient             | Doctor              | Email Address               | Phone       | Address");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
        IEnumerable<Patient> patients = (IEnumerable<Patient>)_service.GetPeople().Where(person => person.Role == RolesEnum.Patient);
        foreach (var patient in patients)
        {
            var doctor = (Doctor)_service.GetPersonById(patient.DoctorID);
            PrintPatient.Print(patient, doctor);
        }
    }

    public void ListAllDoctors()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("All Doctors");
        Console.WriteLine();
        Console.WriteLine("All doctors registered to the DOTNET Hospital Management System:");
        Console.WriteLine("\nName                 | Email Address               | Phone       | Address");        
        Console.WriteLine("------------------------------------------------------------------------------------------------------");

        IEnumerable<Doctor> doctors = (IEnumerable<Doctor>)_service.GetPeople().Where(person => person.Role == RolesEnum.Doctor);
        foreach (var doctor in doctors)
        {
            doctor.PrintSelf();
        }
    }

    public void ListByID()
    {
        _service.GetPersonById(9);
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
