using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Output;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalConsoleApp.Hospital.People;

public class Patient : Person
{
    public Patient(int id, string name, string email, string phone, string address, string password, int doctorID = 0) : base(id, name, email, phone, address, RolesEnum.Patient, password)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Role = RolesEnum.Patient;
        DoctorID = doctorID;
        Password = password;
    }

    [ForeignKey("DoctorID")]
    public int DoctorID { get; set; }

    //Override of Base menu method
    public override void Menu(Database.HospitalService service)
    {
        _service = service;
        bool cont = true;
        while (cont)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Patient Menu");
            Console.WriteLine($"Welcome to DOTNET Hospital Management System {Name}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List patient details");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all appointments");
            Console.WriteLine("4. Book appointment");
            Console.WriteLine("5. Exit to Login");
            Console.WriteLine("6. Exit System");

            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    ViewDetails();
                    break;
                case '2':
                    ViewDoctorDetails();
                    break;
                case '3':
                    ViewAppointments();
                    break;
                case '4':
                    BookAppointment();
                    break;
                case '5':
                    cont = false;
                    break;
                case '6':
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid input, please input a number between 1 and 6.");
                    Console.ReadKey();
                    break;
            }
        }
        Logout();
    }

    //Prints patient details
    public override void ViewDetails()
    {
        PrintPatient.Print(this);
    }

    //Books an appointment
    public void BookAppointment()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("Book Appointment");

        if (DoctorID == 0)
        {
            AddDoctor();
        }

        var doctor = _service.GetPersonById(DoctorID) as Doctor;
        Console.WriteLine($"You are booking an appointment with {doctor.Name}");
        Console.Write("Please enter the description of the appointment:");
        string description;
        try 
        { 
            description = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input, please try again.");
            Console.ReadKey();
            return;
        }

        _service.AddAppointment(this, doctor, description);
        try
        {
            Appointment appointment = new Appointment(this, doctor, description);
            appointment.SendEmail();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to send email");
        }
        Console.WriteLine("Appointment booked successfully!");
        Console.ReadKey();
    }

    //Get all appointments for the patient
    public IEnumerable<Appointment> GetAppointments()
    {
        return _service.GetAppointments().Where(a => a.Patient.Id == Id || a.Doctor.Id == Id);
    }

    //View all appointments for the patient
    public void ViewAppointments()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("My Appointments");
        ListAppointments.Appointments(this);
    }

    //View the details of the doctor assigned to the patient
    public void ViewDoctorDetails()
    {
        BaseConsoleCommands.Clear();
        BaseConsoleCommands.Header("My Doctor");

        if (DoctorID == 0)
        {
            AddDoctor();
        }

        var doctor = _service.GetPersonById(DoctorID) as Doctor;
        PrintDoctor.PrintDoctorInfo(doctor, false);
    }

    //extension method to assign a doctor to the patient
    private void AddDoctor()
    {
        Console.WriteLine("You are not registered with any doctor! Please choose which doctor you would like to register with.");
        var doctors = _service.GetPeople().Where(p => p.Role == RolesEnum.Doctor);

        int i = 1;
        foreach (Doctor d in doctors)
        {
            Console.Write($"{i}: ");
            d.PrintSelf();
            i++;
        }
        Console.Write("Please select a doctor: ");
        int id;
        try
        {
            id = int.Parse(Console.ReadKey().KeyChar.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input, please try again.");
            Console.ReadKey();
            return;
        }
        DoctorID = doctors.ElementAt(id - 1).Id;
    }

    //Prints table header for patients
    public override string ToString()
    {
        return "Patient             | Doctor              | Email Address               | Phone       | Address\n" +  "------------------------------------------------------------------------------------------------------------------------";
    }
}
