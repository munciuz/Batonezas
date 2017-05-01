using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IImageRepository : IRepository<Image>
    {
    }

    public class ImageRepository : Repository<Image>, IImageRepository
    {
    }
}