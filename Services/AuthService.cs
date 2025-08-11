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
        private readonly IGuestServices _guestServices;
        private readonly IDataEntered _dataEntered;

        public AuthService(IGuestServices guestServices, IDataEntered dataEntered)
        {
            _guestServices = guestServices ?? throw new ArgumentNullException(nameof(guestServices));
            _dataEntered = dataEntered ?? throw new ArgumentNullException(nameof(dataEntered));
        }

        // SignUp function 
        public void SignUp()
        {
            //int guestId = _dataEntered.EnterGuestId();
            string firstName = _dataEntered.EnterGuestFirstName();
            string lastName = _dataEntered.EnterGuestLastName();
            string nationalId = _dataEntered.EnterGuestNationalID();
            string phone = _dataEntered.EnterGuestPhoneNumber();
            string password = _dataEntered.EnterPasswordForSignUp();
            _guestServices.AddNewGuest(firstName, lastName, nationalId, phone, password);
        }

        // SignIn function
        public bool SignIn()
        {
            // 1) Ask for ID
            string NationalID = _dataEntered.EnterGuestNationalID();
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
                string rawPassword = _dataEntered.ReadPassword();

                bool PassValid = Validation.PasswordVlidate.ValidatePassword(rawPassword);
                if (!PassValid)
                {
                    Console.WriteLine("Invalid password format. Password must be 3 characters long.");
                    return false;
                }

                // hash the entered password exactly the same way you hashed when signing up
                string enteredHash = _dataEntered.HashPassword(rawPassword);

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
