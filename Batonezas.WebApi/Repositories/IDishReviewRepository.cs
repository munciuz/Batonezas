using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IDishTypeRepository : IRepository<DishType>
    {
    }

    public class DishTypeRepository : Repository<DishType>, IDishTypeRepository
    {
    }
}