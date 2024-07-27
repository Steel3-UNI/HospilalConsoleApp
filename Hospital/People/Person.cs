using System;
using System.Collections.Generic;
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

    public int Id { get; set; }

    public string Name { get; set; }

    public RolesEnum Role { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public abstract void PrintMenu();

    public abstract void ViewDetails();

    public void Logout()
    {

    }

    public void Exit()
    {

    }
}
