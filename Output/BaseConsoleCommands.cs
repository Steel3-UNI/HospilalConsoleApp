using HospitalConsoleApp.Database;
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
                        "|                                                      |\n";

        Console.Write(header);

        Console.Write('|');
        Console.SetCursorPosition(27 - menuName.Length / 2, Console.CursorTop);
        Console.Write(menuName);
        Console.SetCursorPosition(55, Console.CursorTop);
        Console.WriteLine("|\n" +
                        "|______________________________________________________|\n");

    }
}
