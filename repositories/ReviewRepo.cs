using HotelRoom_Architecture_DataAnnotation_FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.repositories
{
    public class ReviewRepo
    {
        private readonly HotelRoomManagementDBContext _context;
        public ReviewRepo(HotelRoomManagementDBContext context)
        {
            _context = context;
        }

        // Add a new review to the database
        public void AddReview(Review review)
        {
            _context.Reviews.Add(review); // Adds the new review to the context
            _context.SaveChanges(); // Saves changes to the database
        }
    }
}
