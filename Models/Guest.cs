using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // for ForeignKey attribute
using Microsoft.EntityFrameworkCore;   // <-- needed for [Index]

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    [Table("Guests")]
    [Index(nameof(NationalID), IsUnique = true)] // <-- creates unique index
    public class Guest
    {
        // Guest class representing a hotel guest with properties for ID, name, email, phone number, and associated reservations.
        [Key]
        public int GuestId { get; set; }

        [Required, StringLength(100)]
        public string Fname { get; set; } = default!;
        [Required, StringLength(100)]
        public string Lname { get; set; } = default!;


        [Required, StringLength(50)]
        public string NationalID { get; set; } = string.Empty;

        [Required,Phone]
        public string Phone { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Password { get; set; } = string.Empty;


        public ICollection <Reservation> Reservations { get; set; } = new List<Reservation>(); // navigation property to reservations

    }
}
