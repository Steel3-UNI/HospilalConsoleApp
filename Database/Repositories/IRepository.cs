using System.Linq.Expressions;

namespace HospitalConsoleApp.Database;

// Generic repository interface
public interface IRepository<T> where T : class
{
    T GetById(int id); // Get entity by ID
    IEnumerable<T> GetAll(); // Get all entities
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate); // Find entities by predicate
    void Add(T entity); // Add entity
    void Update(T entity); // Update entity
    void Remove(T entity); // Remove entity
    void SaveChanges(); // Save changes to database
}