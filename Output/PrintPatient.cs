using HospitalConsoleApp.Hospital.People;

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

    public static void Print(Patient p, string doctorName)
    {
        Console.Write($"{p.Name}");
        Console.SetCursorPosition(20, Console.CursorTop);
        Console.Write($"| {doctorName}");
        Console.SetCursorPosition(41, Console.CursorTop);
        Console.Write($"| {p.Email}");
        Console.SetCursorPosition(71, Console.CursorTop);
        Console.Write($"| {p.Phone}");
        Console.SetCursorPosition(86, Console.CursorTop);
        Console.Write($"| {p.Address}");
        Console.WriteLine();
    }
}
