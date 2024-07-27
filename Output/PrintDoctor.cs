using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Output;

public class PrintDoctor
{
    static void PrintDoctor(Doctor doctor, bool isSelf)
    {
        BaseConsoleCommands.Header(isSelf ? "My Details" : "My Doctor");
        Console.WriteLine(isSelf ? "": "\nMy Doctor");
        Console.WriteLine();
        Console.WriteLine()
    }
}
