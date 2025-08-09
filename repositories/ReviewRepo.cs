﻿using HotelRoom_Architecture_DataAnnotation_FluentAPI;
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

        // Get all reviews from the database
        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList(); // Fetches all reviews from the database
        }

        // Get a review by its ID
        public Review GetReviewById(int reviewId)
        {
            return _context.Reviews.Find(reviewId); // Finds a review by its ID
        }

        // Update an existing review
        public void UpdateReview(Review review)
        {
            _context.Reviews.Update(review); // Updates the review in the context
            _context.SaveChanges(); // Saves changes to the database
        }
        // Delete a review by its ID
        public void DeleteReview(int reviewId)
        {
            var review = GetReviewById(reviewId); // Retrieves the review by its ID
            if (review != null)
            {
                _context.Reviews.Remove(review); // Removes the review from the context
                _context.SaveChanges(); // Saves changes to the database
            }
        }

    }
}
