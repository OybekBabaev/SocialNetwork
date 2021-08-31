using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using System;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new();

        static void Main()
        {
            Console.WriteLine("Welcome to Socialnaya Set!");
            
            while (true)
            {
                Console.WriteLine("Enter first name to start user registration: ");
                string firstName = Console.ReadLine();
                Console.Write("last name: ");
                string lastName = Console.ReadLine();
                Console.Write("password: ");
                string password = Console.ReadLine();
                Console.Write("email: ");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Signed up successfully");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter data correctly");
                }
                catch (Exception)
                {
                    Console.WriteLine("Registration error occured");
                }
            }
        }
    }
}
