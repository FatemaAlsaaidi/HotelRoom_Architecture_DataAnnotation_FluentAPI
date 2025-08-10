using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace HotelRoomDB.Data
{
    public class DataEntered
    {

        /// ======================================= Guest Data =================================
        // 1. Enter Guest ID
        public int EnterGuestId()
        {
            Console.Write("Enter Guest ID: ");
            int guestId = int.Parse(Console.ReadLine());
            return guestId;
        }

        // 2. Enter Guest First Name
        public string EnterGuestFirstName()
        {
            Console.Write("Enter Guest First Name: ");
            string firstName = Console.ReadLine();
            return firstName;
        }

        // 3. Enter Guest Last Name
        public string EnterGuestLastName()
        {
            Console.Write("Enter Guest Last Name: ");
            string lastName = Console.ReadLine();
            return lastName;
        }

        // 4. Enter Guest National ID
        public string EnterGuestNationalID()
        {
            Console.Write("Enter Guest National ID: ");
            string nationalId = Console.ReadLine();
            return nationalId;
        }

        // 5. Enter Guest Phone Number
        public string EnterGuestPhoneNumber()
        {
            Console.Write("Enter Guest Phone Number: ");
            string phoneNumber = Console.ReadLine();
            return phoneNumber;
        }
        // 6. Enter Guest Password
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 3)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        // 6.1 Generates a SHA256 hash for the given password.
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        //6.2 Implement the user to enter and confirm a password during sign-up.
        public static string EnterPasswordForSignUp()
        {
            int tries = 0;

            while (tries < 3)
            {
                Console.Write("Enter a new password (must be 6 digit or more) : ");
                string password = ReadPassword();

                // Validate password (at least 6 chars, contains letter & number)
                bool validPassword = Validation.PasswordVlidate.ValidatePassword(password);

                if (!validPassword)
                {
                    Console.WriteLine("\n Password must be at least 3 characters long and contain letters and numbers.");
                    tries++;
                    continue;
                }

                Console.Write("Confirm password: ");
                string confirmPassword = ReadPassword();

                if (password == confirmPassword)
                {
                    string hashedPassword = HashPassword(password);
                    Console.WriteLine("\n Password set successfully!");
                    return hashedPassword;
                }
                else
                {
                    Console.WriteLine("\n  Passwords do not match. Try again.");
                    tries++;
                }
            }

            Console.WriteLine("\n  You have exceeded the maximum number of attempts.");
            return "null";
        }

        /// ======================================= Room Data =================================



    }
}
