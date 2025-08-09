using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IReservationRepo


namespace HotelRoomDB.Services
{
    public class ReservationServices
    {
        // Constructor Injection 
        private readonly IReservationRepo _reservationRepository;
        public ReservationServices(IReservationRepo reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }
    }
}
