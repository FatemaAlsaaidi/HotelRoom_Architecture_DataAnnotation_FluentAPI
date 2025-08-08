using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Room
    {
        // Room class representing a hotel room with properties for ID, room number, daily rate, and reservation status.
        [key]
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; } // Unique

        [Range(100, double.MaxValue)]
        public decimal DailyRate { get; set; }

        [Required]
        public bool IsReserved { get; set; } 
    }
}
