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





    }
}
