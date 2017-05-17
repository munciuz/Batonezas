using System.Linq;
using Batonezas.DataAccess;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IPlaceTypeService
    {
        void CreatePlaceTypesForPlace(int placeId, string[] gTypes);
    }

    public class PlaceTypeService : IPlaceTypeService
    {
        private readonly IPlaceTypeRepository placeTypeRepository;
        private readonly IPlacePlaceTypeRepository placePlaceTypeRepository;
            
        public PlaceTypeService(IPlaceTypeRepository placeTypeRepository, 
            IPlacePlaceTypeRepository placePlaceTypeRepository)
        {
            this.placeTypeRepository = placeTypeRepository;
            this.placePlaceTypeRepository = placePlaceTypeRepository;
        }

        public void CreatePlaceTypesForPlace(int placeId, string[] gTypes)
        {
            if (gTypes == null) return;

            foreach (var gType in gTypes)
            {
                var placeType = placeTypeRepository.CreateQuery().SingleOrDefault(x => x.GName == gType);

                if (placeType != null)
                {
                    var placePlaceType = new PlacePlaceType
                    {
                        PlaceId = placeId,
                        PlaceTypeId = placeType.Id
                    };

                    placePlaceTypeRepository.Insert(placePlaceType);
                }
            }
        }
    }
}