using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IPlaceReviewRepository : IRepository<PlaceReview>
    {
    }

    public class PlaceReviewRepository : Repository<PlaceReview>, IPlaceReviewRepository
    {
    }
}