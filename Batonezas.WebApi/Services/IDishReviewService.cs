using System;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishReviewService
    {
        void Create(DishReviewEditModel model);
    }

    public class DishReviewService : IDishReviewService
    {
        private readonly IDishReviewRepository dishReviewRepository;
        private readonly IReviewRepository reviewRepository;

        public DishReviewService(IDishReviewRepository dishReviewRepository, 
            IReviewRepository reviewRepository)
        {
            this.dishReviewRepository = dishReviewRepository;
            this.reviewRepository = reviewRepository;
        }

        public void Create(DishReviewEditModel model)
        {
            model.DishId = 3;

            var review = new Review
            {
                CreatedByUserId = 1,
                CreatedDateTime = DateTime.Now,
                Text = model.Review,
                PlaceId = 2,
                IsValid = true,
                Rating = model.Rating
            };

            reviewRepository.Insert(review);

            if (model.DishId.HasValue)
            {
                var dishReview = new DishReview
                {
                    DishId = model.DishId.Value,
                    ReviewId = review.Id
                };

                dishReviewRepository.Insert(dishReview);
            }
            else
            {
            }
        }
    }
}