using HospitalConsoleApp.Database;
using HospitalConsoleApp.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public class Patient : Person
{
    public Patient(int id, string name, string email, string phone, string address, string password) : base(id, name, email, phone, address, RolesEnum.Patient, password)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Role = RolesEnum.Patient;
        DoctorID = 0;
        Password = password;
    }

    [ForeignKey("DoctorID")]
    public int DoctorID { get; set; }

    public override void Menu(Database.HospitalService service)
    {
        

        _service = service;
        bool cont = true;
        while (cont)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Patient Menu");
            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List patient details");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all appointments");
            Console.WriteLine("4. Book appointment");
            Console.WriteLine("5. Exit to Login");
            Console.WriteLine("6. Exit System");

            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ViewDetails();
                    break;
                case '2':
                    ViewDoctorDetails();
                    break;
                case '3':
                    ViewAppointments();
                    break;
                case '4':
                    BookAppointment();
                    break;
                case '5':
                    cont = false;
                    break;
                case '6':
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 6.");
                    break;
            }
        }
        Logout();
    }

    public override void ViewDetails()
    {
        PrintPatient.Print(this);
    }

    public void BookAppointment()
    {
        if (DoctorID == 0)
        {
            
        }
    }

    public void ViewAppointments()
    {

    }

    public void ViewDoctorDetails()
    {

    }
}
