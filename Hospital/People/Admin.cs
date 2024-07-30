using HospitalConsoleApp.Database;
using HospitalConsoleApp.Output;

namespace HospitalConsoleApp.Hospital.People;

public class Admin : Person
{
    public Admin(int id, string name, string password) : base(id, name, string.Empty, string.Empty, string.Empty, RolesEnum.Admin, password)
    {
        Id = id;
        Name = name;
        Role = RolesEnum.Admin;
        Email = "";
        Phone = "";
        Password = password;
    }

    HospitalService _service;

    public override void Menu(HospitalService service)
    {
        _service = service;
        bool cont = true;
        while (cont)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Administrator Menu");

            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List all doctors");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all patients");
            Console.WriteLine("4. Check patient details");
            Console.WriteLine("5. Add doctor");
            Console.WriteLine("6. Add patient");
            Console.WriteLine("7. Exit to Login");
            Console.WriteLine("8. Exit System");

            var input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ListAllDoctors();
                    break;
                case '2':
                    ListByID(RolesEnum.Doctor);
                    break;
                case '3':
                    ListAllPatients();
                    break;
                case '4':
                    ListByID(RolesEnum.Patient);
                    break;
                case '5':
                    Add(RolesEnum.Doctor);
                    break;
                case '6':
                    Add(RolesEnum.Patient);
                    break;
                case '7':
                    cont = false;
                    break;
                case '8':
                    Exit(_service);
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 8.");
                    break;
            }
        }
        Logout(_service);
    }

    public override void ViewDetails()
    {
        throw new NotSupportedException();
    }

    public void ListAllPatients()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("All Patients");
        Console.WriteLine($"\nAll patients registered to the DOTNET Hospital Management System:\n");
        Console.WriteLine("Patient             | Doctor              | Email Address               | Phone       | Address");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
        IEnumerable<Patient> patients = _service.GetPeople().Where(p => p.Role == RolesEnum.Patient).OfType<Patient>();
        foreach (var patient in patients)
        {
            var doctor = (Doctor)_service.GetPersonById(patient.DoctorID);
            PrintPatient.Print(patient, doctor);
        }

        Console.ReadKey();
    }

    public void ListAllDoctors()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("All Doctors");
        Console.WriteLine();
        Console.WriteLine("All doctors registered to the DOTNET Hospital Management System:");
        Console.WriteLine("\nName                 | Email Address               | Phone       | Address");        
        Console.WriteLine("------------------------------------------------------------------------------------------------------");

        IEnumerable<Doctor> doctors = _service.GetPeople().Where(p => p.Role == RolesEnum.Doctor).OfType<Doctor>();
        foreach (var doctor in doctors)
        {
            doctor.PrintSelf();
        }

        Console.ReadKey();
    }

    public void ListByID(RolesEnum role)
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header(role == RolesEnum.Patient ? "Patient Details" : "Doctor Details");
        
        Console.Write("\nPlease ente rthe ID of the ");
        Console.Write(role == RolesEnum.Patient ? "patient" : "doctor");
        Console.WriteLine(" whose details you are checking. Or press n to return to menu");
        var id = Console.ReadLine();
        if (id == "n")
        {
            return;
        }

        var iid = int.Parse(id);

        if (role == RolesEnum.Doctor)
        {
            var doctor = _service.GetPersonById(iid) as Doctor;
            PrintDoctor.PrintDoctorInfo(doctor, true);
            return;
        }
        else
        {
            Console.WriteLine("Patient             | Doctor              | Email Address               | Phone       | Address");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            var patient = _service.GetPersonById(iid) as Patient;
            PrintPatient.Print(patient, (Doctor)_service.GetPersonById(patient.DoctorID));
        }

        _service.GetPersonById(iid);



        Console.ReadKey();
    }

    public void Add(RolesEnum role)
    {
        BaseConsoleCommands.Clear();
        Random rand = new Random();
        string id = rand.Next(40000, 50000).ToString();
        switch (role)
        {
            case RolesEnum.Doctor:
                BaseConsoleCommands.Header("Add Doctor");

                Console.WriteLine("Enter doctor name:");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter doctor email:");
                string Email = Console.ReadLine();
                Console.WriteLine("Enter doctor phone:");
                string Phone = Console.ReadLine();
                Console.WriteLine("Enter doctor address:");
                string Address = Console.ReadLine();

                try 
                {
                    _service.AddPerson(id: id, name:Name, role: role, email: Email, phone: Phone, address: Address);
                    Console.WriteLine($"{Name} added to the system!");
                    Console.WriteLine($"The users system id is: {id}");
                }
                catch(Exception e)
                {
                    Console.WriteLine("One or more of the inputted values is incorrect" + e.Message);
                }
                break;

            case RolesEnum.Patient:
                BaseConsoleCommands.Header("Add Patient");

                Console.WriteLine("Enter patient name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter patient email:");
                Email = Console.ReadLine();
                Console.WriteLine("Enter patient phone:");
                Phone = Console.ReadLine();
                Console.WriteLine("Enter patient address:");
                Address = Console.ReadLine();

                try
                {
                    _service.AddPerson(id: id, name: Name, role: role, Email, Phone, Address);
                    Console.WriteLine($"{Name} added to the system!");
                    Console.WriteLine($"The users system id is: {id}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("One or more of the inputted values is incorrect" + e.Message);
                }
                break;

            default:
                break;
        }
        Console.ReadLine();
    }
}
