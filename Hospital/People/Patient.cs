using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public class Patient : Person
{
    public Patient(int id, string name, string email, string phone, string address) : base(id, name, email, phone, address, RolesEnum.Patient)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Role = RolesEnum.Patient;
    }

    public override void PrintMenu()
    {
        throw new NotImplementedException();
    }

    public override void ViewDetails()
    {
        throw new NotImplementedException();
    }

    public void BookAppointment()
    {

    }

    public void ViewAppointments()
    {

    }

    public void ViewDoctorDetails()
    {

    }

    public int DoctorID { get; set; }
}
