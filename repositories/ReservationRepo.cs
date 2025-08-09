using HotelRoom_Architecture_DataAnnotation_FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.repositories
{
    public class ReservationRepo : IReservationRepo
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

        // Get a reservation by its ID
        public Reservation GetReservationById(int reservationId)
        {
            return _context.Reservations.Find(reservationId); // Finds a reservation by its ID
        }

        // Update an existing reservation
        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation); // Updates the reservation in the context
            _context.SaveChanges(); // Saves changes to the database
        }

        // Delete a reservation by its ID
        public void DeleteReservation(int reservationId)
        {
            var reservation = GetReservationById(reservationId); // Retrieves the reservation by its ID
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation); // Removes the reservation from the context
                _context.SaveChanges(); // Saves changes to the database
            }
        }

        // exist reservation 
        public bool ExistsOverlap(int roomId, DateTime start, DateTime end)
        {
            return _context.Reservations.Any(r =>
                r.RoomId == roomId &&
                r.Status != "Cancelled" &&
                start < r.CheckOutDate &&
                end > r.CheckInDate
            );
        }

    }
}
