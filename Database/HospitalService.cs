using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Hospital.People;
using HospitalConsoleApp.Output;
using System.Linq.Expressions;

namespace HospitalConsoleApp.Database;

public class HospitalService
{
    private readonly PersonRepo _personRepository;     // Repository for managing persons
    private readonly AppointmentRepo _appointmentRepository; // Repository for managing appointments

    // Constructor to initialize repositories via dependency injection
    public HospitalService(PersonRepo personRepository, AppointmentRepo appointmentRepository)
    {
        _personRepository = personRepository;
        _appointmentRepository = appointmentRepository;
    }

    // Method to add a new appointment to the library
    public void AddAppointment(Patient p, Doctor d, string desc)
    {
        // Create a new Appointment object with provided name
        var appointment = new Appointment(p, d, desc);
        // Add the appointment to the repository
        _appointmentRepository.Add(appointment);
        // Save changes to the database
        _appointmentRepository.SaveChanges();
    }

    // Method to add a new person to the library
    public int AddPerson(string id, string name, RolesEnum role, string pass = "Test", string email = "", string phone = "", string address = "", int doctorID = 0)
    {
        Person person;
        switch (role)
        {
            case RolesEnum.Patient:
                // Create a new Patient object with provided details
                if(doctorID != 0)
                {
                    person = new Patient(int.Parse(id), name, email, phone, address, pass, doctorID);
                }
                else
                {
                    person = new Patient(int.Parse(id), name, email, phone, address, pass);
                }
                break;
            case RolesEnum.Doctor:
                // Create a new Doctor object with provided details
                person = new Doctor(int.Parse(id), name, email, phone, address, pass);
                break;
            default:
                // Create a new Admin object with provided name
                person = new Admin(int.Parse(id), name, pass);
                break;
        }
        // Add the person to the repository
        _personRepository.Add(person);
        // Save changes to the database
        _personRepository.SaveChanges();
        return person.Id; // Return the newly created person id
    }

    public void DeleteAllPersons()
    {
        // Delete all persons
        IEnumerable<Person> personsToDelete = _personRepository.GetAllPeople(); // Retrieve all persons to delete them
        foreach (Person person in personsToDelete)
        {
            _personRepository.Remove(person); // Delete each person
        }
        _personRepository.SaveChanges();
    }

    public void DeleteAllAppointments()
    {
        // Delete all appointments
        IEnumerable<Appointment> appointmentsToDelete = _appointmentRepository.GetAllAppointments(); // Retrieve all appointments to delete them
        foreach (Appointment appointment in appointmentsToDelete)
        {
            _appointmentRepository.Remove(appointment); //Delete each appointment
        }
    }

    public Person GetPersonById(int id)
    {
        return _personRepository.GetPersonById(id); // Retrieve a person by its id
    }

    public IEnumerable<Person> GetPeople()
    {
        return _personRepository.GetAllPeople(); // Retrieve all persons
    }

    public IEnumerable<Person> GetPeopleOnCondition(Expression<Func<Person, bool>> predicate)
    {
        return _personRepository.GetPeopleOnCondition(predicate); // Retrieve all persons by role
    }

    public IEnumerable<Appointment> GetAppointments()
    {
        return _appointmentRepository.GetAllAppointments(); // Retrieve all appointments
    }

    //SartUp function
    public void Run()
    {
        SeedData();
        Login.Logon(this);
    }

    public void SeedData()
    {
        // Delete all persons and appointments
        DeleteAllPersons();
        DeleteAllAppointments();

        // Add new people
        int person1Id = AddPerson("10001", "Mark Ureta", RolesEnum.Patient, "Hello", "playingHigh666@gmail.com", "0477193810", "4 Boston Avenue Wollindilly", 20001);
        int person2Id = AddPerson("10002", "Injur Ree", RolesEnum.Patient, "Test", "superman@gmail.com", "0475673083", "23 Real street Sydney", 20001);
        int person3Id = AddPerson("10003", "Tooth Hurty", RolesEnum.Patient, "Test", "superman@gmail.com", "0475673083", "Seeded data blvd Dotnet", 20002);
        int person4Id = AddPerson("10004", "Joe Rogan", RolesEnum.Patient, "Test", "superman@gmail.com", "0475673083", "Seeded data blvd Dotnet", 20002);
        int person5Id = AddPerson("10005", "Donald Trump", RolesEnum.Patient, "Test", "playingHigh666@gmail.com", "0475673083", "Used to be the white house", 20003);
        int person6Id = AddPerson("10006", "David Patientson", RolesEnum.Patient, "Test", "dotnethospital69@gmail.com", "0475673083", "23 Real street Sydney", 20003);
        int person7Id = AddPerson("20001", "Jack Doctorson", RolesEnum.Doctor, "Test", "dotnethospital69@gmail.com", "0475673083", "948 Dpctor Drive Sydney");
        int person8Id = AddPerson("20002", "Louis Villella", RolesEnum.Doctor, "Test", "dotnethospital69@gmail.com", "0475673083", "23 Real street Sydney");
        int person9Id = AddPerson("20003", "MyParentsDreams", RolesEnum.Doctor, "Test", "dotnethospital69@gmail.com", "0475673083", "23 Real street Sydney");
        int person10Id = AddPerson("11111", "Admin Ostrator", RolesEnum.Admin, "Test");

        _personRepository.SaveChanges();

        // Add new appointments
        AddAppointment((Patient)GetPersonById(person1Id), (Doctor)GetPersonById(person7Id), "Checkup");
        AddAppointment((Patient)GetPersonById(person2Id), (Doctor)GetPersonById(person7Id), "Surgery");
        AddAppointment((Patient)GetPersonById(person3Id), (Doctor)GetPersonById(person8Id), "Dental");
        AddAppointment((Patient)GetPersonById(person4Id), (Doctor)GetPersonById(person8Id), "Checkup");
        AddAppointment((Patient)GetPersonById(person5Id), (Doctor)GetPersonById(person9Id), "Checkup");
        AddAppointment((Patient)GetPersonById(person6Id), (Doctor)GetPersonById(person9Id), "Checkup");
        AddAppointment((Patient)GetPersonById(person1Id), (Doctor)GetPersonById(person7Id), "flu");
        AddAppointment((Patient)GetPersonById(person5Id), (Doctor)GetPersonById(person9Id), "Sore Ear");
        AddAppointment((Patient)GetPersonById(person2Id), (Doctor)GetPersonById(person7Id), "Checkup");
        AddAppointment((Patient)GetPersonById(person5Id), (Doctor)GetPersonById(person9Id), "Follow Up");

        _personRepository.SaveChanges();
    }
}
