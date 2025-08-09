namespace HotelRoomDB.Services
{
    public interface IGuestServices
    {
        void AddNewGuest(int guestId, string fname, string lname, string nationalID, string phone);
        void GetAllGuest();
        void GetGuestById(int guestId);
        void RemoveGuest(int guestId);
        void UpdateGuest(int GuestID, string phone);
    }
}