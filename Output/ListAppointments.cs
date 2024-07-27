using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Output;

public class ListAppointments
{
    public static void Appointments(Patient person)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("My Appointments");
        Console.WriteLine();
        Console.WriteLine($"Appointments for {person.Name}");


    }

    void AppointmentsBase()
    {

    }
}
