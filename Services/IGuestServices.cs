using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.Services
{
    public interface IGuestServices
    {
        void AddNewGuest(int guestId, string fname, string lname, string nationalID, string phone, string password);
        void GetAllGuest();
        Guest GetGuestById(int guestId);
        void RemoveGuest(int guestId);
        void UpdateGuest(int GuestID, string phone);
    }
}