using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IDishRepository : IRepository<Dish>
    {
    }

    public class DishRepository : Repository<Dish>, IDishRepository
    {
    }
}