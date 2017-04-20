using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {
    }
}