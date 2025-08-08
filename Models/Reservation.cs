using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Reservation
    {
        // Reservation class representing a hotel room reservation with properties for ID, guest name, number of nights, booking date, and associated room.
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string GuestName { get; set; } = default!;

        [Range(1, int.MaxValue)]
        public int Nights { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        // Foreign key to Room
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;
        

    }
}
