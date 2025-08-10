using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomDB.Validation
{
    public class NationalIDValidate
    {
        public string ValidateNationalID()
        {
            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();
            // Check if the National ID is null or empty
            if (string.IsNullOrWhiteSpace(nationalId))
            {
                Console.WriteLine("National ID cannot be null or empty.");
                return null;
            }
            // Check if the National ID is exactly 14 characters long
            if (nationalId.Length != 4)
            {
                Console.WriteLine("National ID must be exactly 4 characters long.");
                return null;
            }
            // Check if the National ID contains only digits
            if (!nationalId.All(char.IsDigit))
            {
                Console.WriteLine("National ID must contain only digits.");
                return null;
            }
            return nationalId; // Return the valid National ID
        }
    }
}
