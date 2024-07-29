using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Hospital.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Database;

public class AppointmentRepo : Repository<Appointment>
{
    public AppointmentRepo(HospitalContext context) : base(context)
    { 
    }

    public HospitalContext hospitalContext
    {
        get { return _context as HospitalContext; }
    }

    public IEnumerable<Appointment> GetAppointmentByPerson(Person person)
    {
        return hospitalContext.Appointments.ToList();
    }

    public IEnumerable<Appointment> GetAllAppointments()
    {
        //return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).ToList();
        return hospitalContext.Appointments.ToList();
    }
}
