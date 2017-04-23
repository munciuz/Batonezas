using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IDishTagRepository : IRepository<DishTag>
    {
    }

    public class DishTagRepository : Repository<DishTag>, IDishTagRepository
    {
    }
}