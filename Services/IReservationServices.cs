
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.Services
{
    public interface IReservationServices
    {
        (bool Ok, string Message, int? ReservationId) AddNewBooking(int resId, int nights, DateTime checkInDate, string NationalId, int roomId);
        (bool Ok, string Massage, int ResID) CancelBooking(int ResId, int RoomID);
        (bool Ok, string Massage) UpdateBooking(int ResId, int RoomID);
        Reservation GetBookingById(int resId);
        List<Reservation> GetAllBookings();
        List<Reservation> GetAllBookingsByGuestId(int guestId);
    }
}