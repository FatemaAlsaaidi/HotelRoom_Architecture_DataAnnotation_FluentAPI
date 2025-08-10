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
    public class AuthService
    {
        // Constructor to inject the repository
        private readonly IGuestServices _GuestServices;
        private readonly IDataEntered _DataEntered;
        public AuthService(IGuestServices GuestService) => _GuestServices = GuestService;
        public AuthService(IDataEntered DataEntered) => _DataEntered = DataEntered;

        // SignUp function 
        public void SignUp()
        {
            int guestId = _DataEntered.EnterGuestId();
            string firstName = _DataEntered.EnterGuestFirstName();
            string lastName = _DataEntered.EnterGuestLastName();
            string nationalId = _DataEntered.EnterGuestNationalID();
            string phone = _DataEntered.EnterGuestPhoneNumber();
            string password = _DataEntered.EnterPasswordForSignUp();
            _GuestServices.AddNewGuest(guestId, firstName, lastName, nationalId, phone, password);
        }

        // SignIn function
        public bool SignIn()
        {
            // 1) Ask for ID
            int guestId = _DataEntered.EnterGuestId();
            var guest = _GuestServices.GetGuestById(guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found. Please sign up first.");
                return false;
            }

            // 2) Up to 3 attempts
            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write("Enter Password (or press Enter to cancel): ");
                string rawPassword = _DataEntered.ReadPassword();

                bool PassValid = Validation.PasswordVlidate.ValidatePassword(rawPassword);
                if (!PassValid)
                {
                    Console.WriteLine("Invalid password format. Password must be 3 characters long.");
                    return false;
                }

                // hash the entered password exactly the same way you hashed when signing up
                string enteredHash = _DataEntered.HashPassword(rawPassword);

                // NOTE: make sure the property name matches your model (Password / HashPassword)
                string? savedHash = guest.Password; // or guest.HashPassword

                if (!string.IsNullOrEmpty(savedHash) &&
                    string.Equals(savedHash, enteredHash, StringComparison.Ordinal))
                {
                    Console.WriteLine($"Welcome {guest.Fname} {guest.Lname}!");
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
