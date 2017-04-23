using System;
using System.Collections.Generic;
using System.Linq;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishReviewService
    {
        void Create(DishReviewEditModel model);
        IList<DishReviewListItemModel> GetList(DishReviewListFilterModel filter);
        DishReviewPageModel GetPageModel();
    }

    public class DishReviewService : IDishReviewService
    {
        private readonly IDishReviewRepository dishReviewRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IDishRepository dishRepository;
        private readonly ITagService tagsseService;
        private readonly IPlaceService placeService;
        private readonly IDishService dishService;

        public DishReviewService(IDishReviewRepository dishReviewRepository, 
            IReviewRepository reviewRepository, 
            IDishRepository dishRepository, 
            ITagService tagsseService, 
            IPlaceService placeService, 
            IDishService dishService)
        {
            this.dishReviewRepository = dishReviewRepository;
            this.reviewRepository = reviewRepository;
            this.dishRepository = dishRepository;
            this.tagsseService = tagsseService;
            this.placeService = placeService;
            this.dishService = dishService;
        }

        public void Create(DishReviewEditModel model)
        {
            int dishId = 0;
            int placeId = placeService.GetPlaceId(model.Place);

            if (!model.DishId.HasValue)
            {
                var dish2 = new Dish
                {
                    CreatedByUserId = 1,
                    CreatedDateTime = DateTime.Now,
                    Name = model.DishName,
                    IsConfirmed = false,
                    IsValid = true
                };

                dishRepository.Insert(dish2);

                dishId = dish2.Id;
            }

            var review = new Review
            {
                CreatedByUserId = 1,
                CreatedDateTime = DateTime.Now,
                Text = model.Review,
                PlaceId = placeId,
                IsValid = true,
                Rating = model.Rating
            };

            reviewRepository.Insert(review);
            
            var dishReview = new DishReview
            {
                DishId = dishId,
                ReviewId = review.Id
            };

            dishService.CreateDishTags(model.TagIdList, dishId);

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

        public DishReviewPageModel GetPageModel()
        {
            var reviews = GetList(new DishReviewListFilterModel());

            var tags = tagsseService.GetList(new TagListFilterModel());

            return new DishReviewPageModel
            {
                DishReviewList = reviews.ToArray(),
                TagList = tags.ToArray()
            };
        }
    }
}