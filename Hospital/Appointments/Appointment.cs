using HospitalConsoleApp.Hospital.People;
using System.Net.Mail;
using System.Net;

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

    //Prints appointment details
    public void Print()
    {
        Console.WriteLine($"{Doctor.Name,-22} | {Patient.Name,-24} | {Description}");
    }

    //Sends an email to the patient that booked the appointment
    public void SendEmail()
    {
        var fromEmail = "dotnethospital69@gmail.com";
        string password = "ehtv ytag haym elmu";

        SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = "New appointment at DOTNET Hospital",
            Body = $"Hello {Patient.Name}, you have booked an appointment with our doctor {Doctor.Name} at DOTNET Hospital for reason: {Description}. Please contact your doctor at {Doctor.Phone} if you have any concerns. Thank you.",
            IsBodyHtml = false
        };

        mailMessage.To.Add(Patient.Email);

        client.Send(mailMessage);
    }

}
