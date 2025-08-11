using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.repositories
{
    public interface IGuestRepo
    {
        void AddGuest(Guest guest);
        void DeleteGuest(string guestNationalID);
        List<Guest> GetAllGuests();
        Guest GetGuestByNationalID(string NationalID);
        void UpdateGuest(Guest guest);
    }
}