using HospitalConsoleApp.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public class Doctor : Person
{
    public Doctor(int id, string name, string email, string phone, string address) : base(id, name, email, phone, address, RolesEnum.Doctor)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Role = RolesEnum.Doctor;
    }

    public override void Menu()
    {
        bool cont = true;
        while (cont)
        {
            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List doctor details");
            Console.WriteLine("2. List Patients");
            Console.WriteLine("3. List appointments");
            Console.WriteLine("4. Check particular patient");
            Console.WriteLine("5. List appointments with patient");
            Console.WriteLine("6. Exit to Login");
            Console.WriteLine("7. Exit System");

            var input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ViewDetails();
                    break;
                case '2':
                    ListPatients();
                    break;
                case '3':
                    ListAppointments();
                    break;
                case '4':
                    CheckPatient(1);
                    break;
                case '5':
                    ListAppointments(1);
                    break;
                case '6':
                    cont = false;
                    break;
                case '7':
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 7.");
                    break;
            }
        }
        Logout();
    }

    public override void ViewDetails()
    {
        PrintDoctor.PrintDoctorInfo(this, true);
    }

    public void ListPatients()
    {

    }

    public void ListAppointments()
    {

    }

    public void ListAppointments(int id)
    {
        Console.WriteLine("Enter patient id:");
        id = Convert.ToInt32(Console.ReadLine());
    }

    public void CheckPatient(int id)
    {
        Console.WriteLine("Enter patient id:");
        id = Convert.ToInt32(Console.ReadLine());
    }
}
