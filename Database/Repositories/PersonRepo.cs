using HospitalConsoleApp.Hospital.People;
using System.Linq.Expressions;

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
        return hospitalContext.People.SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return hospitalContext.People.ToList();
    }

    public IEnumerable<Person> GetPeopleOnCondition(Expression<Func<Person, bool>> predicate)
    {
        return hospitalContext.People.Where(predicate).ToList();
    }
}
