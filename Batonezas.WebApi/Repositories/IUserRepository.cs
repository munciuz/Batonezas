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
        private readonly IRoleRepository roleRepository;

        public UserRepository(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IList<string> GetRoles(int userId)
        {
            var user = Get(userId);

            return user.Role.Select(x => x.Name).ToList();
        }
    }
}