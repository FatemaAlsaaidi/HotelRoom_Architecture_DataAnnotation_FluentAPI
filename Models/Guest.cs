using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Guest
    {
        // Guest class representing a hotel guest with properties for ID, name, email, phone number, and associated reservations.
        [key]
        public int GuestId { get; set; }

        [Required, StringLength(100)]
        public string Fname { get; set; } = default!;
        [Required, StringLength(100)]
        public string Lname { get; set; } = default!;


        [Required, StringLength(50)]
        public string NationalID { get; set; }

        [Required,Phone]
        public string Phone { get; set; }

        public ICollection <Reservation> Reservations { get; set; } = new List<Reservation>(); // navigation property to reservations

    }
}
