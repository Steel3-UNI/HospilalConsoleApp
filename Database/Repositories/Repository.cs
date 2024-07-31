using System.Linq.Expressions;


namespace HospitalConsoleApp.Database;

// Generic repository implementation
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly HospitalContext _context; // Database context instance

    public Repository(HospitalContext context)
    {
        _context = context; // Injected database context
    }

    public virtual T GetById(int id)
    {
        return _context.Set<T>().Find(id); // Find entity by ID
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList(); // Retrieve all entities
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).ToList(); // Find entities by predicate
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity); // Add entity to DbSet
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity); // Update entity in DbSet
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity); // Remove entity from DbSet
    }

    public virtual void SaveChanges()
    {
        _context.SaveChanges(); // Save changes to the database
    }
}

