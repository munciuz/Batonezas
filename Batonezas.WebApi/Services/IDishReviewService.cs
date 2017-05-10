using System;
using System.Collections.Generic;
using System.Linq;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishReviewService
    {
        DishReviewEditModel Get(int id);
        void Create(DishReviewEditModel model);
        IList<DishReviewListItemModel> GetList(DishReviewListFilterModel filter);
        DishReviewPageModel GetPageModel();
        IList<GroupedDishReviewListItemModel> GetGroupedList(DishReviewListFilterModel filter);
    }

    public class DishReviewService : IDishReviewService
    {
        private readonly IDishReviewRepository dishReviewRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IDishRepository dishRepository;
        private readonly ITagService tagsseService;
        private readonly IPlaceService placeService;
        private readonly IDishService dishService;
        private readonly IImageService imageService;

        public DishReviewService(IDishReviewRepository dishReviewRepository,
            IReviewRepository reviewRepository,
            IDishRepository dishRepository,
            ITagService tagsseService,
            IPlaceService placeService,
            IDishService dishService, 
            IImageService imageService)
        {
            this.dishReviewRepository = dishReviewRepository;
            this.reviewRepository = reviewRepository;
            this.dishRepository = dishRepository;
            this.tagsseService = tagsseService;
            this.placeService = placeService;
            this.dishService = dishService;
            this.imageService = imageService;
        }

        public DishReviewEditModel Get(int id)
        {
            var dishReview = dishReviewRepository.Get(id);

            var model = new DishReviewEditModel
            {
                Id = dishReview.Id,
                DishId = dishReview.DishId,
                DishName = dishReview.Dish.Name,
                Review = dishReview.Review.Text,
                Rating = dishReview.Review.Rating,
                Tags = dishReview.Dish.DishTag.Select(x => new TagEditModel
                {
                    Id = x.TagId,
                    Name = x.Tag.Name
                }).ToArray()
            };

            return model;
        }

        public void Create(DishReviewEditModel model)
        {
            int dishId = model.DishId ?? 0;
            int placeId = placeService.GetPlaceId(model.Place);

            if (!model.DishId.HasValue)
            {
                var newDish = new Dish
                {
                    CreatedByUserId = 1,
                    CreatedDateTime = DateTime.Now,
                    Name = model.DishName,
                    IsConfirmed = false,
                    IsValid = true
                };

                dishRepository.Insert(newDish);

                dishId = newDish.Id;
            }

            int? imageId = null;

            if (!string.IsNullOrEmpty(model.ImageUri))
            {
                imageId = imageService.CreateImage(model.ImageUri);
            }

            var review = new Review
            {
                CreatedByUserId = 1,
                CreatedDateTime = DateTime.Now,
                Text = model.Review,
                PlaceId = placeId,
                IsValid = true,
                Rating = model.Rating,
                ImageId = imageId
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
            var reviews = dishReviewRepository.CreateQuery().Where(x => x.DishId == filter.DishId && x.Review.PlaceId == filter.PlaceId).ToList();

            var result = reviews.Select(x => new DishReviewListItemModel
            {
                Id = x.Id,
                DishId = x.DishId,
                GId = x.Review.Place.GId,
                Name = x.Dish.Name,
                Review = x.Review.Text,
                Rating = x.Review.Rating,
                ImageUri = GetImageUri(x.Review.Image?.Original),
                ReviewedBy = x.Review.User.UserName
            });

            return result.ToList();
        }

        public IList<GroupedDishReviewListItemModel> GetGroupedList(DishReviewListFilterModel filter)
        {
            var reviews = (from dr in dishReviewRepository.CreateQuery()
                group dr by new {dr.DishId, dr.Review.PlaceId}).ToList();

            var result = reviews.Select(x => new GroupedDishReviewListItemModel
            {
                DishId = x.Key.DishId,
                DishName = x.FirstOrDefault().Dish.Name,
                PlaceId = x.FirstOrDefault().Review.PlaceId,
                PlaceName = x.FirstOrDefault().Review.Place.Name,
                GId = x.FirstOrDefault().Review.Place.GId,
                RatingAverage = x.Average(y => y.Review.Rating),
                ReviewCount = x.Count(),
                TagsIds = x.FirstOrDefault().Dish.DishTag.Select(y => y.TagId).ToArray(),
                ImageUri = imageService.GetImagePath(x.FirstOrDefault().Review.ImageId)
            }).OrderByDescending(x => x.RatingAverage).ToList();

            return result;
        }

        public DishReviewPageModel GetPageModel()
        {
            var reviews = GetGroupedList(new DishReviewListFilterModel());

            var tags = tagsseService.GetList(new TagListFilterModel());

            var dishes = dishService.GetList(new DishListFilterModel());

            return new DishReviewPageModel
            {
                DishReviewList = reviews.ToArray(),
                TagList = tags.ToArray(),
                DishList = dishes.ToArray()
            };
        }

        public string GetImageUri(byte[] bytes)
        {
            if (bytes == null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(bytes);
            string imageDataURL = string.Format("data:image/jpeg;base64,{0}", imageBase64Data);

            return imageDataURL;
        }
    }
}