using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IGuestRepo


namespace HotelRoomDB.Services
{
    public class GuestServices
    {
        // Constructor Injection 
        private readonly IGuestRepo _guestRepository;
        public GuestServices(IGuestRepo guestRepository)
        {
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        }
        // Add methods for guest services here, e.g., GetGuestById, AddGuest, UpdateGuest, DeleteGuest, etc.
    }
}
