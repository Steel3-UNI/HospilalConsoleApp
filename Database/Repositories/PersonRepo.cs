using HospitalConsoleApp.Hospital.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Database;

public class PersonRepo : Repository<Person>
{
    public PersonRepo(HospitalContext context) : base(context)
    {
    }
    public HospitalContext hospitalContext
    {
        get { return _context as HospitalContext; }
    }

    public Person GetPersonById(int id)
    {
        return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Person> GetPeopleByRole(RolesEnum role)
    {
        return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).Where(p => p.Role == role).ToList();
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return hospitalContext.People.Include(p => p.Name).Include(p => p.Email).Include(p => p.Phone).Include(p => p.Address).ToList();
    }
}
