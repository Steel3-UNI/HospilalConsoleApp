using HospilalConsoleApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospilalConsoleApp.Output
{
    public class Login
    {
        public void Logon()
        {
            BaseConsoleCommands.Clear();
            BaseConsoleCommands.Header("Login");

            Console.WriteLine("Id: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");

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

            Console.WriteLine("Valid Credentials");
            
            var person = 

            BaseConsoleCommands.Menu(person);
        }   
    }
}
