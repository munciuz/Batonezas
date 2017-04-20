using System;
using System.Collections.Generic;
using System.Linq;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishReviewService
    {
        void Create(DishReviewEditModel model);
        IList<DishReviewListItemModel> GetList(DishReviewListFilterModel filter);
    }

    public class DishReviewService : IDishReviewService
    {
        private readonly IDishReviewRepository dishReviewRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IDishRepository dishRepository;

        public DishReviewService(IDishReviewRepository dishReviewRepository, 
            IReviewRepository reviewRepository, 
            IDishRepository dishRepository)
        {
            this.dishReviewRepository = dishReviewRepository;
            this.reviewRepository = reviewRepository;
            this.dishRepository = dishRepository;
        }

        public void Create(DishReviewEditModel model)
        {
            int dishId;
            var dish = dishRepository.CreateQuery().SingleOrDefault(x => x.Name == model.DishName);

            if (dish != null)
            {
                dishId = dish.Id;
            }
            else
            {
                var newDish = new Dish
                {
                    CreatedByUserId = 1,
                    CreatedDateTime = DateTime.Now,
                    Name = model.DishName,
                    IsConfirmed = false,
                    IsValid = true,
                    DishTypeId = model.DishTypeId ?? 1
                };

                dishRepository.Insert(newDish);

                dishId = newDish.Id;
            }

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
            
            var dishReview = new DishReview
            {
                DishId = dishId,
                ReviewId = review.Id
            };

            dishReviewRepository.Insert(dishReview);
        }

        public IList<DishReviewListItemModel> GetList(DishReviewListFilterModel filter)
        {
            var result = dishReviewRepository.CreateQuery().Select(x => new DishReviewListItemModel
            {
                Id = x.Id,
                Name = x.Dish.Name,
                Review = x.Review.Text,
                Rating = x.Review.Rating,
                ImageUri = "nothing to show"
            });

            return result.ToList();
        }
    }
}