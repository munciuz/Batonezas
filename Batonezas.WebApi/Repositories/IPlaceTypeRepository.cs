using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IPlaceTypeRepository : IRepository<PlaceType>
    {
    }

    public class PlaceTypeRepository : Repository<PlaceType>, IPlaceTypeRepository
    {
    }
}