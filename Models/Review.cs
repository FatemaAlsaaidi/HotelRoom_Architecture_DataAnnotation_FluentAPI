using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Review
    {
        // Review class representing a hotel room review with properties for ID, rating, comment, and associated reservation.
        public int ReviewId { get; set; }
        public int Rating { get; set; } // Rating out of 5
        public string Comment { get; set; } = default!;
    }
}
