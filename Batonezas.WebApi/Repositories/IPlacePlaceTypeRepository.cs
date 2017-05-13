using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IPlacePlaceTypeRepository : IRepository<PlacePlaceType>
    {
    }

    public class PlacePlaceTypeRepository : Repository<PlacePlaceType>, IPlacePlaceTypeRepository
    {
    }
}