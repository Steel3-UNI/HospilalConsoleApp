using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Output;

namespace HospitalConsoleApp.Hospital.People;

public class Doctor : Person
{
    public Doctor(int id, string name, string email, string phone, string address, string password) : base(id, name, email, phone, address, RolesEnum.Doctor, password)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Role = RolesEnum.Doctor;
        Password = password;
    }

    Database.HospitalService _service;

    public override void Menu(Database.HospitalService service)
    {
        _service = service;
        bool cont = true;
        while (cont)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Doctor Menu");

            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List doctor details");
            Console.WriteLine("2. List Patients");
            Console.WriteLine("3. List appointments");
            Console.WriteLine("4. Check particular patient");
            Console.WriteLine("5. List appointments with patient");
            Console.WriteLine("6. Exit to Login");
            Console.WriteLine("7. Exit System");

            var input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ViewDetails();
                    break;
                case '2':
                    ListPatients();
                    break;
                case '3':
                    ListAppointments.Appointments(this);
                    break;
                case '4':
                    CheckPatient();
                    break;
                case '5':
                    ListAppointments.AppointmentsById(this);
                    break;
                case '6':
                    cont = false;
                    break;
                case '7':
                    Exit(_service);
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 7.");
                    Console.ReadKey();
                    break;
            }
        }
        Logout(_service);
    }

    public override void ViewDetails()
    {
        PrintDoctor.PrintDoctorInfo(this, true);
    }

    public void ListPatients()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("My Patients");
        Console.WriteLine();

        IEnumerable<Patient> pats = _service.GetPeople().Where(p => p.Role == RolesEnum.Patient).OfType<Patient>();
        var docPats = pats.Where(p => p.DoctorID == Id);
        Console.WriteLine($"Patients assigned to: {Name}\n");
        Console.WriteLine(docPats.FirstOrDefault().ToString());
        foreach (Patient pat in docPats)
        {
            PrintPatient.Print(pat, this);
        }
        Console.ReadKey();
    }

    public IEnumerable<Appointment> GetAppointments()
    {
        return _service.GetAppointments().Where(app => app.Doctor.Id == Id);
    }

    public void CheckPatient()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("Check Patient Details");

        Console.Write("Enter patient id:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        Patient pat = (Patient)_service.GetPersonById(id);
        Console.WriteLine(pat.ToString());

        PrintPatient.Print(pat, this);
        Console.ReadKey();
    }

    public void PrintSelf()
    {
        Console.Write($"{Name}");
        Console.SetCursorPosition(20, Console.CursorTop);
        Console.Write($"| {Email}");
        Console.SetCursorPosition(50, Console.CursorTop);
        Console.Write($"| {Phone}");
        Console.SetCursorPosition(64, Console.CursorTop);
        Console.Write($"| {Address}");
        Console.WriteLine();
    }
}
