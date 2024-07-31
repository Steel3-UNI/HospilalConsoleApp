using HospitalConsoleApp.Hospital.People;
using System.Linq.Expressions;

namespace HospitalConsoleApp.Database;

public class PersonRepo : Repository<Person>
{
    public PersonRepo(HospitalContext context) : base(context)
    {
    }

    //Gets database context
    public HospitalContext hospitalContext
    {
        get { return _context; }
    }

    //returns the person with the given Id, or returns null if not found
    public virtual Person GetPersonById(int id)
    {
        return hospitalContext.People.SingleOrDefault(p => p.Id == id);
    }

    //Returns all people in the database
    public virtual IEnumerable<Person> GetAllPeople()
    {
        return hospitalContext.People.ToList();
    }

    //Returns all people in the database that satisfy the given condition
    public virtual IEnumerable<Person> GetPeopleOnCondition(Expression<Func<Person, bool>> predicate)
    {
        return hospitalContext.People.Where(predicate).ToList();
    }
}
