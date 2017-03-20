using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IUserRepository : ISRepository<User>
    {
    }

    public class UserRepository : SRepository<User>, IUserRepository
    {
    }
}