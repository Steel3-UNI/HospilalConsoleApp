using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Hospital.People;

namespace HospitalConsoleApp.Output;

public class ListAppointments
{
    //Each method lists the appointments for the respective person with the help of the AppointmentsBase method
    public static void Appointments(Patient patient)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("My Appointments");
        Console.WriteLine();
        Console.WriteLine($"Appointments for {patient.Name}");
        IEnumerable<Appointment> appointments = patient.GetAppointments();
        AppointmentsBase(appointments);
    }

    public static void Appointments(Doctor doctor)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("All Appointments");
        Console.WriteLine();
        Console.WriteLine($"Appointments for {doctor.Name}");
        IEnumerable<Appointment> appointments = doctor.GetAppointments();
        AppointmentsBase(appointments);
    }

    public static void AppointmentsById(Doctor doctor)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("Appointments With");
        Console.WriteLine();
        Console.WriteLine("Enter the ID of the patient to check:");
        int id = int.Parse(Console.ReadLine());
        IEnumerable<Appointment> appointments = doctor.GetAppointments().Where(appointment => appointment.Patient.Id == id);
        AppointmentsBase(appointments);
    }

    //extension method
    static void AppointmentsBase(IEnumerable<Appointment> appointments)
    {
        Console.WriteLine();
        Console.WriteLine("Doctor                 | Patient                  | Description\n" +
                          "-------------------------------------------------------------------------------------------------");

        foreach(var appointment in appointments)
        {
            appointment.Print();
        }

        Console.ReadLine();
    }
}
