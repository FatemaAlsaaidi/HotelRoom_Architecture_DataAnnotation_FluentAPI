namespace HotelRoomDB.Data
{
    public interface IDataEntered
    {
        // ======================================= Guest Data =================================
        string EnterGuestFirstName();
        int EnterGuestId();
        string EnterGuestLastName();
        string EnterGuestNationalID();
        string EnterGuestPhoneNumber();
        string EnterPasswordForSignUp();
        string HashPassword(string password);
        string ReadPassword();

        // ======================================= Room Data =================================
        decimal EnterDailyRate();
        bool EnterRoomAvailability();

        int EnterRoomId();

        // =================================== Reservation Data ===========================
        DateTime EnterCheckInDate();
        DateTime EnterCheckOutDate();
        int EnterReservationId();
        int EnterGuestIdForReservation();
        int EnterRoomIdForReservation();
        int EnterNights();

        // =================================== Review Data ===========================
        int EnterReviewId();
        int EnterRating();
        string EnterReviewText();

    }
}