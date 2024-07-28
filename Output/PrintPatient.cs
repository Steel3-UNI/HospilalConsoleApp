using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Output;

public class PrintPatient
{
    public static void Print(Patient p)
    {
        BaseConsoleCommands.Header("My Details");
        Console.WriteLine();
        Console.WriteLine($"{p.Name}'s Details");
        Console.WriteLine();
        Console.WriteLine($"Patient Id: {p.Id}");
        Console.WriteLine($"Full Name: {p.Name}");
        Console.WriteLine($"Address: {p.Address}");
        Console.WriteLine($"Email: {p.Email}");
        Console.WriteLine($"Phone: {p.Phone}");

        Console.ReadKey();
    }
}
