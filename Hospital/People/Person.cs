using HospitalConsoleApp.Database;
using HospitalConsoleApp.Output;
using System.ComponentModel.DataAnnotations;

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

    public abstract void Menu(HospitalService service);

    public abstract void ViewDetails();

    public void Logout()
    {
        Login.Logon(_service);
    }

    public void Exit()
    {
        _service.DeleteAllPersons();
        _service.DeleteAllAppointments();
        Environment.Exit(0);
    }
}
