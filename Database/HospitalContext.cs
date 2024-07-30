using HospitalConsoleApp.Hospital.Appointments;
using HospitalConsoleApp.Hospital.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalConsoleApp.Database;

public class HospitalContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Person> People { get; set; }
    public string DbPath { get; }

    public HospitalContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "Hospital.db");
        Console.WriteLine("Database path:" + DbPath);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configures the context to use SQLite as the database provider
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
