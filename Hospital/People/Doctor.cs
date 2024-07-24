using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospilalConsoleApp.Hospital.People
{
    public class Doctor : Person
    {
        public Doctor(int id, string name, string email, string phone, string address) : base(id, name, email, phone, address, RolesEnum.Doctor)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Role = RolesEnum.Doctor;
        }

        public override void PrintMenu()
        {
            throw new NotImplementedException();
        }

        public override void ViewDetails()
        {
            throw new NotImplementedException();
        }

        public void ListPatients()
        {

        }

        public void ListAppointments()
        {

        }

        public void ListAppointments(int  id)
        {

        }

        public void CheckPatient(int id)
        {

        }
    }
}
