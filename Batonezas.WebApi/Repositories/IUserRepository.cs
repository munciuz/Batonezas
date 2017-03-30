using System.Collections.Generic;
using System.Linq;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IList<string> GetRoles(int userId);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public IList<string> GetRoles(int userId)
        {
            var user = Get(userId);

            return user.Role.Select(x => x.Name).ToList();
        }
    }
}