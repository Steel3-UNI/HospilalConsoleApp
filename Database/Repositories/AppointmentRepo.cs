using HospitalConsoleApp.Hospital.Appointments;

namespace HospitalConsoleApp.Database;

public class AppointmentRepo : Repository<Appointment>
{
    public AppointmentRepo(HospitalContext context) : base(context)
    { 
    }

    //Gets the database context
    public HospitalContext hospitalContext
    {
        get { return _context; }
    }

    //Gets all appointments
    public virtual IEnumerable<Appointment> GetAllAppointments()
    {
        return hospitalContext.Appointments.ToList();
    }
}
