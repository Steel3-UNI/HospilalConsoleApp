﻿using HospitalConsoleApp.Database;
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

    public void Logout(HospitalService service)
    {
        Login.Logon(service);
    }

    public void Exit(HospitalService service)
    {
        _service = service;
        _service.DeleteAllPersons();
        _service.DeleteAllAppointments();
        Environment.Exit(0);
    }
}
