using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.Services
{
    public interface IGuestServices
    {
        void AddNewGuest(string fname, string lname, string nationalID, string phone, string password);
        void GetAllGuest();
        Guest GetGuestByNationalID(string NationalID);
        void RemoveGuest(string NationalID);
        void UpdateGuest(string NationalID, string phone);
    }
}