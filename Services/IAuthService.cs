namespace HotelRoomDB.Services
{
    public interface IAuthService
    {
        bool SignIn();
        void SignUp();
    }
}