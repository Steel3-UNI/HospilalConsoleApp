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

public abstract class Person(int id, string name, string email, string phone, string address, RolesEnum role, string password)
{
    [Key]
    public int Id { get; set; } = id;

    public string Name { get; set; } = name;

    public RolesEnum Role { get; set; } = role;

    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public string Address { get; set; } = address;

    public string Password { get; set; } = password;

    public HospitalService _service;

    public abstract void Menu(Database.HospitalService service);

    public abstract void ViewDetails();

    public IEnumerable<Appointment> GetAppointments()
    {
        return _service.GetAppointments().Where(a => a.Patient.Id == Id || a.Doctor.Id == Id);
    }

    public void Logout()
    {
        Login.Logon(_service);
    }

    public void Exit()
    {
        Environment.Exit(0);
    }
}
