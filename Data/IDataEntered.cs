namespace HotelRoomDB.Data
{
    public interface IDataEntered
    {
        string EnterGuestFirstName();
        int EnterGuestId();
        string EnterGuestLastName();
        string EnterGuestNationalID();
        string EnterGuestPhoneNumber();
        string EnterPasswordForSignUp();
        string HashPassword(string password);
        string ReadPassword();
    }
}