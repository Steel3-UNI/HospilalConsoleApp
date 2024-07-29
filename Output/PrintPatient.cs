using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalConsoleApp.Output;

public class PrintPatient
{
    public static void Print(Patient p)
    {
        BaseConsoleCommands.Clear();
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

    public static void Print(Patient p, Doctor d)
    {
        Console.Write($"{p.Name}");
        Console.SetCursorPosition(20, Console.CursorTop);
        Console.Write($"| {d.Name}");
        Console.SetCursorPosition(41, Console.CursorTop);
        Console.Write($"| {p.Email}");
        Console.SetCursorPosition(71, Console.CursorTop);
        Console.Write($"| {p.Phone}");
        Console.SetCursorPosition(86, Console.CursorTop);
        Console.Write($"| {p.Address}");
    }
}
