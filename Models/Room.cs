using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Room
    {
        // Room class representing a hotel room with properties for ID, room number, daily rate, and reservation status.
        public int RoomId { get; set; }

        public decimal DailyRate { get; set; }

        public bool IsReserved { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>(); // navigation property to reservations

    }
}
