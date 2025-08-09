using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // for ForeignKey attribute


namespace HotelRoom_Architecture_DataAnnotation_FluentAPI.Models
{
    public class Review
    {
        // Review class representing a hotel room review with properties for ID, rating, comment, and associated reservation.
        [Key]
        public int ReviewId { get; set; }
        [Required, Range(1,5)]
        public int Rating { get; set; } // Rating out of 5

        [Required, StringLength(500)]
        public string Comment { get; set; } = default!;

        // relationShip between Review and Reservation
        [ForeignKey("Reservation")]
        public int ResId { get; set; } // Foreign key to Reservation
        public Reservation Reservation { get; set; } = default!; // Navigation property to Room


    }
}
