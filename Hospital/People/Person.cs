using HospitalConsoleApp.Database;
using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Output;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public abstract class Person
{
    public Person(int id, string name, string email, string phone, string address, RolesEnum role)
    {
        Id = id;
        Name = name;
        Role = role;
        Email = email;
        Phone = phone;
        Address = address;
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public RolesEnum Role { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public HospitalService _service;

    public abstract void Menu(Database.HospitalService service);

    public abstract void ViewDetails();

    public IEnumerable<Appointment> GetAppointments()
    {
        return _service.GetAppointments().Where(a => a.Patient.Id == Id || a.Doctor.Id == Id);
    }

    public void Logout()
    {
        BaseConsoleCommands.Logout();
    }

    public void Exit()
    {
        Environment.Exit(0);
    }
}
