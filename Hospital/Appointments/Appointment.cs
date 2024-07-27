using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.Appointments;

public class Appointment
{
    public Appointment()
    {
    }

    public Appointment(Patient p, Doctor d, string desc) 
    {
        Patient = p;
        Doctor = d;
        Description = desc;
        AppointmentId = Guid.NewGuid();
    }

    public Guid AppointmentId { get; set; }

    public Patient Patient { get; set; }

    public Doctor Doctor { get; set; }

    public string Description { get; set; }

}
