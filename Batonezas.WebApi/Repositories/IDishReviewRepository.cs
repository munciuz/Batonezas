using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IDishReviewRepository : IRepository<DishReview>
    {
    }

    public class DishReviewRepository : Repository<DishReview>, IDishReviewRepository
    {
    }
}