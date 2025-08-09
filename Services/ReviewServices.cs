using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IReviewRepo


namespace HotelRoomDB.Services
{
    public class ReviewServices
    {
        // Constructor Injection 
        private readonly IReviewRepo _reviewRepository;
        public ReviewServices(IReviewRepo reviewRepository)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }



    }
}
