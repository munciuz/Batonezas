using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Models.PlaceReviewModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IPlaceReviewService
    {
        PlaceEditModel GetPlace(int id);
        PlaceSearchPageModel GetPageModel();
        IList<PlaceReviewListItemModel> GetList(PlaceReviewListFilterModel filter);
        IList<GroupedPlaceReviewListItemModel> GetGroupedList(PlaceReviewListFilterModel filter);
        void Create(PlaceReviewEditModel model);
    }

    public class PlaceReviewService : IPlaceReviewService
    {
        private readonly IPlaceRepository placeRepository;
        private readonly IPlaceReviewRepository placeReviewRepository;
        private readonly IPlaceService placeService;
        private readonly IReviewRepository reviewRepository;
        private readonly IPlaceTypeService placeTypeService;

        public PlaceReviewService(IPlaceRepository placeRepository,
            IPlaceReviewRepository placeReviewRepository,
            IPlaceService placeService,
            IReviewRepository reviewRepository, 
            IPlaceTypeService placeTypeService)
        {
            this.placeRepository = placeRepository;
            this.placeReviewRepository = placeReviewRepository;
            this.placeService = placeService;
            this.reviewRepository = reviewRepository;
            this.placeTypeService = placeTypeService;
        }

        public PlaceEditModel GetPlace(int id)
        {
            var place = placeRepository.Get(id);

            var model = new PlaceEditModel
            {
                Id = place.Id,
                Address = place.Address,
                GId = place.GId,
                Lat = place.Lat,
                Lng = place.Lng,
                Name = place.Name
            };

            return model;
        }

        public IList<GroupedPlaceReviewListItemModel> GetGroupedList(PlaceReviewListFilterModel filter)
        {
            var reviews = from pr in placeReviewRepository.CreateQuery()
                          group pr by new { pr.Review.PlaceId };

            var result = reviews.Select(x => new GroupedPlaceReviewListItemModel
            {
                PlaceId = x.FirstOrDefault().Review.PlaceId,
                PlaceName = x.FirstOrDefault().Review.Place.Name,
                GId = x.FirstOrDefault().Review.Place.GId,
                RatingAverage = x.Average(y => y.Review.Rating),
                ReviewCount = x.Count()
            }).ToList();

            return result;
        }

        public PlaceSearchPageModel GetPageModel()
        {
            var result = new PlaceSearchPageModel
            {
                GroupedPlacesList = GetGroupedList(new PlaceReviewListFilterModel()).ToArray()
            };

            return result;
        }

        [HttpPost]
        public void Create(PlaceReviewEditModel model)
        {
            var placeId = placeService.GetPlaceId(model.Place);

            placeTypeService.CreatePlaceTypesForPlace(placeId, model.Place.GTypes);

            var review = new Review
            {
                Text = model.Review,
                Rating = model.Rating,
                CreatedByUserId = UserHelper.GetCurrentUserId(),
                CreatedDateTime = DateTime.Now,
                PlaceId = placeId,
                IsValid = true
            };

            reviewRepository.Insert(review);

            var placeReview = new PlaceReview
            {
                ReviewId = review.Id
            };

            placeReviewRepository.Insert(placeReview);

            model.Id = placeReview.Id;
        }

        public IList<PlaceReviewListItemModel> GetList(PlaceReviewListFilterModel filter)
        {
            var reviews = placeReviewRepository.CreateQuery().Where(x => x.Review.PlaceId == filter.PlaceId).ToList();

            var result = reviews.Select(x => new PlaceReviewListItemModel
            {
                Id = x.Id,
                GId = x.Review.Place.GId,
                Review = x.Review.Text,
                Rating = x.Review.Rating,
                ReviewedBy = x.Review.User.UserName
            });

            return result.ToList();
        }
    }
}