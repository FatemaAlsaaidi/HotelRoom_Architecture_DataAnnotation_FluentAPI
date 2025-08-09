using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.Services
{
    public interface IReviewServices
    {
        void AddNewReview(int ReviewId, int Rating, string Comment, int ResId);
        void DeleteReview(int reviewId);
        List<Review> GetAllReviews();
        Review GetReviewById(int reviewId);
        void UpdateReview(int reviewId, int rating, string comments);
    }
}