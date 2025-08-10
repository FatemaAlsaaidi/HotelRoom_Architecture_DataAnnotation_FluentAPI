using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IReservationRepo
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.Services
{
    public class ReservationServices : IReservationServices
    {
        // Constructor Injection for IGuestRepo
        private readonly IReservationRepo _reservationRepository;
        public ReservationServices(IReservationRepo reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }
        // Constructor Injection for IGuestRepo
        private readonly IGuestRepo _guestRepository;
        public ReservationServices(IGuestRepo guestRepository)
        {
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        }
        // Constructor Injection 
        private readonly IRoomRepo _roomRepository;
        public ReservationServices(IRoomRepo roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }


        // New booking 
        public (bool Ok, string Message, int? ReservationId) AddNewBooking(int resId, int nights, DateTime checkInDate, int guestId, int roomId)
        {
            // 1) validation for number of night
            if (nights <= 0) return (false, "Number of nights must be greater than 0.", null);

            checkInDate = checkInDate.Date; // normalize to date (00:00)
            var checkOutDate = checkInDate.AddDays(nights);

            // 2) check if room or guest exist
            var room = _roomRepository.GetRoomById(roomId);
            if (room == null) return (false, "There is no room with this id number.", null);

            var guest = _guestRepository.GetGuestById(guestId);
            if (guest == null) return (false, "There is no guest with this id number.", null);

            // 3) avoid booking same room in same date this state named overlaps 
            // Overlaps rule: (startA < endB) && (endA > startB)
            bool overlaps = _reservationRepository.ExistsOverlap(
                roomId, checkInDate, checkOutDate);

            if (overlaps)
                return (false, "Room is not available in the selected dates.", null);

            // 4) create new reserve object
            var reservation = new Reservation
            {
                ResId = resId,
                Nights = nights,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                TotlePrice = room.DailyRate * nights, // decimal * int = decimal
                RoomId = roomId,
                GuestId = guestId,
                Status = "Confirmed" // optional
            };

            // 5) save 
            room.IsReserved = true;

            _reservationRepository.AddReservation(reservation);

            return (true, "Reservation created successfully.", reservation.ResId);
        }

        // cancel booking 
        public (bool Ok, string Massage, int ResID) CancelBooking(int ResId, int RoomID)
        {
            // check if room reserve 
            var Book = _reservationRepository.GetReservationById(ResId);
            if (Book.RoomId == RoomID)
            {
                _reservationRepository.CancelReservation(ResId);
                var room = _roomRepository.GetRoomById(RoomID);
                room.IsReserved = false;
                return (true, "Booking successfully Cancel", Book.ResId);
            }
            else
            {
                return (false, "There is no booking with this room", Book.RoomId);
            }

        }

        // update Booking 
        public (bool Ok, string Massage) UpdateBooking(int ResId, int RoomID)
        {
            var book = _reservationRepository.GetReservationById(ResId);
            if (book != null)
            {
                if (book.RoomId == RoomID)
                {
                    _reservationRepository.UpdateReservation(book);
                    return (true, "Seccussfully Update bokking");

                }
            }
            return (false, "There is no booking with this id");
        }

        // Get Booking by ID
        public Reservation GetBookingById(int resId)
        {
            return _reservationRepository.GetReservationById(resId);
        }
        // Get All Bookings
        public List<Reservation> GetAllBookings()
        {
            return _reservationRepository.GetAllReservations();
        }


    }
}
