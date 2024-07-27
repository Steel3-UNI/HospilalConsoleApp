using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.People;

public class Admin : Person
{
    public Admin(int id, string name) : base(id, name, string.Empty, string.Empty, string.Empty, RolesEnum.Admin)
    {
        Id = id;
        Name = name;
        Role = RolesEnum.Admin;
        Email = "";
        Phone = "";
    }

    public override void PrintMenu()
    {
        throw new NotImplementedException();
    }

    public override void ViewDetails()
    {
        throw new NotSupportedException();
    }

    public void ListAllPatients()
    {
        throw new NotImplementedException();
    }

    public void ListAllDoctors()
    {
        throw new NotImplementedException();
    }

    public void ListByID(int id)
    {
        throw new NotImplementedException();
    }
}
