using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginConsole
{
    internal class Program
    {
        public static bool login(string username, string password)
        {
            if (username == "abc" && password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                if (count==3)
                {
                    Console.WriteLine("You have exceeded the maximum number of attempts. Did you want to try wait for 30 sec");
                    System.Threading.Thread.Sleep(30000);

                    count = 0;                    
                }
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (login(username.ToLower(), password))
                {
                    Console.WriteLine("Login successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Login failed");
                    count++;
                }
            }
        }
    }
}
