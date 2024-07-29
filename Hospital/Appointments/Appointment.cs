using HospitalConsoleApp.Hospital.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsoleApp.Hospital.Appointments;

public class Appointment
{
    public Appointment() { }

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

    public void Print()
    {
        Console.WriteLine($"{Doctor.Name,-20} | {Patient.Name,-20} | {Description}");
    }

    private void SendEmail()
    {
        // Replace this with your gmail email address
        var fromEmail = "dotnethospital69@gmail.com";
        // Replace this with an app password generated at https://myaccount.google.com/apppasswords
        string password = "ehtv ytag haym elmu";

        SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        // Construct a new mail message with the required values
        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = "New appointment at DOTNET Hospital",
            Body = $"Hello {Patient.Name}, you have booked an appointment with our doctor {Doctor.Name} at DOTNET Hospital for reason: {Description}. Please contact your doctor at {Doctor.Phone} if you have any concerns. Thank you.",
            IsBodyHtml = false
        };

        // Add an address to the "to" field
        mailMessage.To.Add(Patient.Email);

        // Send the email
        client.Send(mailMessage);
    }

}
