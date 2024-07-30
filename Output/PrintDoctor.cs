using HospitalConsoleApp.Hospital.People;

namespace HospitalConsoleApp.Output;

public class PrintDoctor
{
    public static void PrintDoctorInfo(Doctor doctor, bool isSelf)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header(isSelf ? "My Details" : "My Doctor");
        Console.WriteLine(isSelf ? "": "\nYour Doctor:\n");

        Console.WriteLine("Name                | Email Address               | Phone       | Address");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        doctor.PrintSelf();
        Console.ReadKey();
    }
}
