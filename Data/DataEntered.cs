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
        public static int EnterGuestId()
        {
            Console.Write("Enter Guest ID: ");
            int guestId = int.Parse(Console.ReadLine());
            return guestId;
        }

        // 2. Enter Guest First Name
        public static string EnterGuestFirstName()
        {
            Console.Write("Enter Guest First Name: ");
            string firstName = Console.ReadLine();
            return firstName;
        }

        // 3. Enter Guest Last Name
        public static string EnterGuestLastName()
        {
            Console.Write("Enter Guest Last Name: ");
            string lastName = Console.ReadLine();
            return lastName;
        }

        // 4. Enter Guest National ID
        public static string EnterGuestNationalID()
        {
            Console.Write("Enter Guest National ID: ");
            string nationalId = Console.ReadLine();
            return nationalId;
        }

        // 5. Enter Guest Phone Number
        public static string EnterGuestPhoneNumber()
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
        // 1. Enter Daily Rate for Room
        public static decimal EnterDailyRate()
        {
            Console.Write("Enter Daily Rate for Room: ");
            decimal dailyRate = decimal.Parse(Console.ReadLine());
            return dailyRate;
        }

        // 2. Enter Room Availability
        public static bool EnterRoomAvailability()
        {
            Console.Write("Is the room available? (yes/no): ");
            string input = Console.ReadLine().ToLower();
            if (input == "no" || input == "n")
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        // 3. Enter Room ID
        public static int EnterRoomId()
        {
            Console.Write("Enter Room ID: ");
            int roomId = int.Parse(Console.ReadLine());
            return roomId;
        }

        /// ====================================== Reservation Data =================================
        public static DateTime EnterCheckInDate()
        {
            Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());
            return checkInDate;
        }
        public static DateTime EnterCheckOutDate()
        {
            Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());
            return checkOutDate;
        }

        public static int EnterReservationId()
        {
            Console.Write("Enter Reservation ID: ");
            int reservationId = int.Parse(Console.ReadLine());
            return reservationId;
        }

        public static int EnterGuestIdForReservation()
        {
            Console.Write("Enter Guest ID for Reservation: ");
            int guestId = int.Parse(Console.ReadLine());
            return guestId;
        }

        public static int EnterRoomIdForReservation()
        {
            Console.Write("Enter Room ID for Reservation: ");
            int roomId = int.Parse(Console.ReadLine());
            return roomId;
        }
        public static int EnterNights()
        {
            Console.Write("Enter Number of Nights: ");
            int nights = int.Parse(Console.ReadLine());
            return nights;

        }

        /// ===================================== Review Data =================================
        public static int EnterReviewId()
        {
            Console.Write("Enter Review ID: ");
            int reviewId = int.Parse(Console.ReadLine());
            return reviewId;
        }
        public static string EnterReviewText()
        {
            Console.Write("Enter Review Content: ");
            string reviewContent = Console.ReadLine();
            return reviewContent;
        }

        public static int EnterRating()
        {
            Console.Write("Enter Rating (1-5): ");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.Write("Invalid input. Please enter a rating between 1 and 5: ");
            }
            return rating;
        }
    }
}
