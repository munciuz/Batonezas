using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
    }

    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
    }
}