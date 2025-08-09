using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IGuestRepo
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


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
        // Add new Guest
        public void AddNewGuest(int guestId, string fname, string lname, string nationalID, string phone)
        {
            var guest = new Guest
            {
                GuestId = guestId,
                Fname = fname,
                Lname = lname,
                NationalID = nationalID,
                Phone = phone
                
            };
            _guestRepository.AddGuest(guest);
        }

        public void RemoveGuest(int guestId) { }
    }
}
