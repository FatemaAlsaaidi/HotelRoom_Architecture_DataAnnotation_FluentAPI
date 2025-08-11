using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.repositories
{
    public interface IReservationRepo
    {
        void AddReservation(Reservation reservation);
        void CancelReservation(int reservationId);
        bool ExistsOverlap(int roomId, DateTime start, DateTime end);
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        void UpdateReservation(Reservation reservation);
        List<Reservation> GetReservationsByGuestId(int guestId);
    }
}