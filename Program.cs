using HospitalConsoleApp.Database;
using HospitalConsoleApp.Output;
using Microsoft.Extensions.DependencyInjection;
using System;

Main();

static void Main()
{
    // Setting up dependency injection container
    ServiceProvider serviceProvider = new ServiceCollection()
        .AddDbContext<HospitalContext>()    // Add LibraryContext as a scoped service
        .AddScoped<PersonRepo>()       // Add Person repo as a scoped service
        .AddScoped<AppointmentRepo>()                       // Add Appointment Repository as a scoped service
        .AddScoped<HospitalService>()                                  // Add HospitalService as a scoped service
        .BuildServiceProvider();           // Build the service provider

    // Retrieve instances of services and repositories
    HospitalService service = serviceProvider.GetService<HospitalService>();       // Retrieve HospitalService instance

    service.Run();
}
