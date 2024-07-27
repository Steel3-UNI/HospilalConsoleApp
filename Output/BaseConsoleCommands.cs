using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Output;

public static class BaseConsoleCommands
{
    public static void Clear()
    {
        Console.Clear();
    }

    public static void Exit()
    {
        Clear();

    }

    public static void Header(string menuName)
    {
        string header = " ______________________________________________________\n" +
                        "|                                                      |\n" +
                        "|           DOTNET Hospital Management System          |\n" +
                        "|______________________________________________________|\n" +
                        "|                                                      |\n" +
                        $"|                      {menuName}                       |\n" +
                        "|______________________________________________________|\n";

        Console.WriteLine(header);
    }

    public static void Logout()
    {
        throw new NotImplementedException();
    }

    public static void Menu(Person person)
    {
        Clear();

        Console.WriteLine($"Welcome to DOTNET Hospital Management System {person.Name}");
        switch (person.Role)
        {
            case RolesEnum.Admin:
                AdminMenu(person);
                break;

            case RolesEnum.Doctor:
                DoctorMenu(person);
                break;

            case RolesEnum.Patient:
                PatientMenu(person);
                break;
        }
    }

    static void AdminMenu(Person person)
    {
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

        Console.ReadKey();
    }

    static void PatientMenu(Person person)
    {
        Console.WriteLine();
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. List patient details");
        Console.WriteLine("2. Check doctor details");
        Console.WriteLine("3. List all appointments");
        Console.WriteLine("4. Book appointment");
        Console.WriteLine("5. Exit to Login");
        Console.WriteLine("6. Exit System");

        Console.ReadKey();
    }

    static void DoctorMenu(Person person)
    {
        Console.WriteLine();
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. List doctor details");
        Console.WriteLine("2. List Patients");
        Console.WriteLine("3. List appointments");
        Console.WriteLine("4. Check particular patient");
        Console.WriteLine("5. List appointmentsn with patient");
        Console.WriteLine("6. Exit to Login");
        Console.WriteLine("7. Exit System");

        Console.ReadKey();
    }
}
