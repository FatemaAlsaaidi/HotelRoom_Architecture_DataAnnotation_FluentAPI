using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IGuestRepo
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.Services
{
    public class GuestServices : IGuestServices
    {
        // Constructor Injection 
        private readonly IGuestRepo _guestRepository;
        public GuestServices(IGuestRepo guestRepository)
        {
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        }
        // Add methods for guest services here, e.g., GetGuestById, AddGuest, UpdateGuest, DeleteGuest, etc.
        // Add new Guest
        public void AddNewGuest(string fname, string lname, string nationalID, string phone, string password)
        {
            var guest = new Guest
            {
                //GuestId = guestId,
                Fname = fname,
                Lname = lname,
                NationalID = nationalID,
                Phone = phone,
                Password = password   


            };
            _guestRepository.AddGuest(guest);
        }
        // Remove Guest
        public void RemoveGuest(string NationalID)
        {
            _guestRepository.DeleteGuest(NationalID);
        }

        // Get All Guest
        public void GetAllGuest()
        {
            _guestRepository.GetAllGuests();
        }

        // get guest by id 
        public Guest GetGuestByNationalID(string NationalID)
        {
           return _guestRepository.GetGuestByNationalID(NationalID);
        }

        // update Phone of guest'
        public void UpdateGuest(string NationalID, string phone)
        {
            var ExistGuest = _guestRepository.GetGuestByNationalID(NationalID);
            if (ExistGuest != null)

                ExistGuest.Phone = phone;
            _guestRepository.UpdateGuest(ExistGuest);
        }



    }
}
