﻿using HospilalConsoleApp.Hospital.Appointments;
using HospilalConsoleApp.Hospital.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospilalConsoleApp.Database
{
    public class AppointmentRepo : Repository<Appointment>
    {
        public AppointmentRepo(HospitalContext context) : base(context)
        { 
        }

        public HospitalContext hospitalContext
        {
            get { return _context as HospitalContext; }
        }

        public Appointment GetAppointmentById(Guid id)
        {
            //return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).SingleOrDefault(p => p.Id == id);
            return new Appointment();
        }

        public IEnumerable<Appointment> GetAppointmentByPerson(Person person)
        {
            return hospitalContext.appointments.ToList();
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            //return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).ToList();
            return hospitalContext.appointments.ToList();
        }
    }
}
