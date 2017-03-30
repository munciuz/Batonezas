using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IPlaceRepository : IRepository<Place>
    {
    }

    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
    }
}