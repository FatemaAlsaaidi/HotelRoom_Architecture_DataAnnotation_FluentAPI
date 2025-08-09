using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; // for ForeignKey attribute

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Reservation
    {
        // Reservation class representing a hotel room reservation with properties for ID, guest name, number of nights, booking date, and associated room.
        [Key]
        public int ResId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Nights { get; set; }
        [Required]
        public double TotlePrice { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        // One-to-One navigation property
        public Review Review { get; set; } = null;

        // Forign key relationships
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; } // navigation to guest 

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; } // navigation to room


    }
}
