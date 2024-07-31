using HospitalConsoleApp.Hospital.People;

namespace HospitalConsoleApp.Output;

public class PrintDoctor
{
    //Prints info of a single doctor
    public static void PrintDoctorInfo(Doctor doctor, bool isSelf)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header(isSelf ? "My Details" : "My Doctor");
        Console.WriteLine(isSelf ? "": "\nYour Doctor:\n");

        Console.WriteLine(doctor.ToString());
        doctor.PrintSelf();
        Console.ReadKey();
    }
}
