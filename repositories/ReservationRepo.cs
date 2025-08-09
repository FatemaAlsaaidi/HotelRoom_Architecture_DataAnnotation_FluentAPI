using HotelRoom_Architecture_DataAnnotation_FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.repositories
{
    public class ReservationRepo
    {
        private readonly HotelRoomManagementDBContext _context;
        public ReservationRepo(HotelRoomManagementDBContext context)
        {
            _context = context;
        }

        // Add a new reservation to the database
        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation); // Adds the new reservation to the context
            _context.SaveChanges(); // Saves changes to the database
        }

        // Get all reservations from the database
        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList(); // Fetches all reservations from the database
        }
    }
}
