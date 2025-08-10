using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
