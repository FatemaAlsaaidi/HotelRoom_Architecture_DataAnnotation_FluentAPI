using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;



namespace HotelRoomDB.repositories
{
    public class GuestRepo : IGuestRepo
    {
        // constructor Injection is used to provide the database context to the repository
        private readonly HotelRoomManagementDBContext _context;
        public GuestRepo(HotelRoomManagementDBContext context)
        {
            _context = context;
        }

        // Add a new guest to the database
        public void AddGuest(Guest guest)
        {
            _context.Guests.Add(guest); // Adds the new guest to the context
            _context.SaveChanges(); // Saves changes to the database
        }

        // Get all guests from the database
        public List<Guest> GetAllGuests()
        {
            return _context.Guests.ToList(); // Fetches all guests from the database
        }

        // Get a guest by their ID
        public Guest GetGuestById(int guestId)
        {
            return _context.Guests.Find(guestId); // Finds a guest by their ID
        }

        // Update an existing guest
        public void UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest); // Updates the guest in the context
            _context.SaveChanges(); // Saves changes to the database
        }

        // Delete a guest by their ID
        public void DeleteGuest(int guestId)
        {
            var guest = GetGuestById(guestId); // Retrieves the guest by their ID
            if (guest != null)
            {
                _context.Guests.Remove(guest); // Removes the guest from the context
                _context.SaveChanges(); // Saves changes to the database
            }
        }
    }
}
