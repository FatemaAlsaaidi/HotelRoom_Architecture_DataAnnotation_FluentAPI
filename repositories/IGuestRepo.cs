using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.repositories
{
    public interface IGuestRepo
    {
        void AddGuest(Guest guest);
        void DeleteGuest(int guestId);
        List<Guest> GetAllGuests();
        Guest GetGuestById(int guestId);
        void UpdateGuest(Guest guest);
    }
}