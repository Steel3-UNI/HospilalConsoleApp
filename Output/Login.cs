using HospitalConsoleApp.Database;
using HospitalConsoleApp.Hospital.People;

namespace HospitalConsoleApp.Output;

public static class Login
{
    public static void Logon(HospitalService service)
    {
        var invalid = false;
        Person user;

        while (true)
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Login");

            if (invalid) { Console.WriteLine("\nInvalid Credentials, please try again"); }

            Console.Write("Id: ");
            var Id = Console.ReadLine();
            if (Id == null) { Id = string.Empty; }

            Console.Write("Password: ");
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            try
            {
                user = service.GetPersonById(int.Parse(Id));
            }
            catch (Exception)
            {
                invalid = true;
                continue;
            }

            if (pass != user.Password)
            {
                invalid = true;
                continue;
            } else
            {
                break;
            }
        }
        Console.WriteLine("\nValid Credentials");
        Console.ReadKey();
        user.Menu(service);
    }   
}
