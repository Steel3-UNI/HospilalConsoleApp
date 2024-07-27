using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public void AddAppointment(Patient p, string desc)
    {
        // Create a new Appointment object with provided name
        var appointment = new Appointment(p, (Doctor)_personRepository.GetPersonById(p.DoctorID), desc);
        // Add the appointment to the repository
        _appointmentRepository.Add(appointment);
        // Save changes to the database
        _appointmentRepository.SaveChanges();
    }

    // Method to add a new person to the library
    public int AddPerson(string id, string name, RolesEnum role, string email = "", string phone = "", string address = "")
    {
        Person person;
        switch (role)
        {
            case RolesEnum.Patient:
                // Create a new Patient object with provided name
                person = new Patient(int.Parse(id), name, email, phone, address);
                break;
            case RolesEnum.Doctor:
                // Create a new Doctor object with provided name
                person = new Doctor(int.Parse(id), name, email, phone, address);
                break;
            default:
                // Create a new Person object with provided name and role
                person = new Admin(int.Parse(id), name);
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

    public void DisplayAppointments()
    {
        IEnumerable<Appointment> appointments = _appointmentRepository.GetAllAppointments();//Retrieve all appointments
        Console.WriteLine("Appointments:");
        foreach (Appointment appointment in appointments)
        {
            Console.WriteLine($"- {appointment.AppointmentId}");     // Display each appointment's name
        }
    }

    public void DisplayPersons()
    {
        IEnumerable<Person> persons = _personRepository.GetAllPeople();        // Retrieve all persons
        Console.WriteLine("Persons:");
        foreach (Person person in persons) // Loop through each person
        {
            //Console.WriteLine($"- {person.Title} by {person.Appointment.Name}"); // Display each person's title and its appointment's name
        }
    }

    public void SeedData()
    {
        // Delete all persons and appointments
        DeleteAllPersons();
        DeleteAllAppointments();

        // Add new people
        int person1Id = AddPerson("10001", "Mark Ureta", RolesEnum.Patient);
        int person2Id = AddPerson("10002", "Injur Ree", RolesEnum.Patient);
        int person3Id = AddPerson("10003", "Tooth Hurty", RolesEnum.Patient);
        int person4Id = AddPerson("10004", "Joe Rogan", RolesEnum.Patient);
        int person5Id = AddPerson("10005", "Doanld Trump", RolesEnum.Patient);
        int person6Id = AddPerson("10006", "David Patientson", RolesEnum.Patient);
        int person7Id = AddPerson("20001", "Jack Doctorson", RolesEnum.Doctor);
        int person8Id = AddPerson("20002", "Louis Vilella", RolesEnum.Doctor);
        int person9Id = AddPerson("20003", "MyParentsHopes AndDremas", RolesEnum.Doctor);
        int person10Id = AddPerson("11111", "Admin Ostrator", RolesEnum.Admin);



        // Display appointments and persons
        DisplayAppointments();
        DisplayPersons();
    }
}
