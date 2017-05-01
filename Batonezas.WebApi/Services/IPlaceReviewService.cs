using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IPlaceReviewService
    {
        PlaceEditModel GetPlace(int id);
    }

    public class PlaceReviewService : IPlaceReviewService
    {
        private readonly IPlaceRepository placeRepository;

        public PlaceReviewService(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
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
    }
}