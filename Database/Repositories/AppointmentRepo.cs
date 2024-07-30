using HospitalConsoleApp.Hospital.Appointments;

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

    public IEnumerable<Appointment> GetAllAppointments()
    {
        return hospitalContext.Appointments.ToList();
    }
}
