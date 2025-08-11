using HotelRoomDB.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;
using HotelRoomDB.Data;

namespace HotelRoomDB.Services
{
    public class AuthService : IAuthService
    {
        // Constructor to inject the repository
        private readonly IGuestServices _guestServices;
        //private readonly IDataEntered _dataEntered;

        public AuthService(IGuestServices guestServices)
        {
            _guestServices = guestServices ?? throw new ArgumentNullException(nameof(guestServices));
        }

        // SignUp function 
        public void SignUp()
        {
            //int guestId = _dataEntered.EnterGuestId();
            string firstName = Data.DataEntered.EnterGuestFirstName();
            string lastName = Data.DataEntered.EnterGuestLastName();
            string nationalId = Data.DataEntered.EnterGuestNationalID();
            string phone = Data.DataEntered.EnterGuestPhoneNumber();
            string password = Data.DataEntered.EnterPasswordForSignUp();
            _guestServices.AddNewGuest(firstName, lastName, nationalId, phone, password);
        }

        // SignIn function
        public bool SignIn()
        {
            // 1) Ask for ID
            string NationalID = Data.DataEntered.EnterGuestNationalID();
            var guest = _guestServices.GetGuestByNationalID(NationalID);

            if (guest == null)
            {
                Console.WriteLine("Guest not found. Please sign up first.");
                Console.ReadLine();
                return false;
            }

            // 2) Up to 3 attempts
            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write("Enter Password (or press Enter to cancel): ");
                string rawPassword = Data.DataEntered.ReadPassword();

                bool PassValid = Validation.PasswordVlidate.ValidatePassword(rawPassword);
                if (!PassValid)
                {
                    Console.WriteLine("Invalid password format. Password must be 3 characters long.");
                    return false;
                }

                // hash the entered password exactly the same way you hashed when signing up
                string enteredHash = Data.DataEntered.HashPassword(rawPassword);

                // NOTE: make sure the property name matches your model (Password / HashPassword)
                string? savedHash = guest.Password; // or guest.HashPassword

                if (!string.IsNullOrEmpty(savedHash) &&
                    string.Equals(savedHash, enteredHash, StringComparison.Ordinal))
                {
                    // Optionally set current user in your app state
                    // Program.CurrentGuest = guest;
                    return true;
                }

                Console.WriteLine(attempt < maxAttempts
                    ? "Invalid password. Try again."
                    : "Invalid password. Sign-in failed.");
            }

            return false;
        }

    }
}
