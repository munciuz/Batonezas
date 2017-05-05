using System.Collections.Generic;
using System.Linq;
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
        IList<GroupedPlaceReviewListItemModel> GetGroupedList(PlaceReviewListFilterModel filter);
    }

    public class PlaceReviewService : IPlaceReviewService
    {
        private readonly IPlaceRepository placeRepository;
        private readonly IPlaceReviewRepository placeReviewRepository;

        public PlaceReviewService(IPlaceRepository placeRepository, 
            IPlaceReviewRepository placeReviewRepository)
        {
            this.placeRepository = placeRepository;
            this.placeReviewRepository = placeReviewRepository;
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
    }
}