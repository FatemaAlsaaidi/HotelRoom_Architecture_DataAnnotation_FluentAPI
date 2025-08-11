using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomDB.Validation
{
    public class PasswordVlidate
    {
        public static bool ValidatePassword(string password) // Validates the password of a user
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 3)
                return false;// Check if the password is null, empty, or not equal 3 characters long
            else return true;
        }

    }
}
