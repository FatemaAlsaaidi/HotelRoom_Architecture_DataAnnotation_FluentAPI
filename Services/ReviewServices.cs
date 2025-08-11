using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IReviewRepo
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;



namespace HotelRoomDB.Services
{
    public class ReviewServices : IReviewServices
    {
        // Constructor Injection 
        private readonly IReviewRepo _reviewRepository;
        public ReviewServices(IReviewRepo reviewRepository)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }
        /// Add methods for review services here, e.g., GetReviewById, AddReview, UpdateReview, DeleteReview, etc.
        // Add new Review to the database through the repository
        public void AddNewReview(int Rating, string Comment, int ResId)
        {
            // Create a new Review object
            var review = new Review
            {
                //ReviewId = ReviewId,
                Rating = Rating,
                Comment = Comment,
                ResId = ResId
            };
            _reviewRepository.AddReview(review);
        }

        // Get All Reviews in the database through the repository
        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        // Get Review by Id from the database through the repository
        public Review GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }
        // Update Review in the database through the repository
        public void UpdateReview(int reviewId, int rating, string comments)
        {
            var existingReview = _reviewRepository.GetReviewById(reviewId);
            if (existingReview != null)
            {
                existingReview.Rating = rating;
                existingReview.Comment = comments;

                _reviewRepository.UpdateReview(existingReview);
            }
        }

        // Delete Review from the database through the repository
        public void DeleteReview(int reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }










    }
}
