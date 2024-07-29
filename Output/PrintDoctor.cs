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

public class PrintDoctor
{
    public static void PrintDoctorInfo(Doctor doctor, bool isSelf)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header(isSelf ? "My Details" : "My Doctor");
        Console.WriteLine(isSelf ? "": "\nYour Doctor:");

        Console.WriteLine("Name                 | Email Address               | Phone       | Address");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        doctor.PrintSelf();
        Console.ReadKey();
    }
}
