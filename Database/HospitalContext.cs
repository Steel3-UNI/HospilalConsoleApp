using HospilalConsoleApp.Hospital.Appointments;
using HospilalConsoleApp.Hospital.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospilalConsoleApp.Database
{
    public class HospitalContext : DbContext
    {
        public DbSet<Appointment> appointments;
        public DbSet<Person> People { get; set; }
        public string DbPath { get; }

        public HospitalContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "library.db");
            Console.WriteLine("Database path:" + DbPath);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the context to use SQLite as the database provider
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
