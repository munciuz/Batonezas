using System.Collections.Generic;
using System.Linq;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IList<string> GetRoles(int userId);
        void DeleteRoles(int userId);
        void CreateUserRole(int userId, int roleId);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IRoleRepository roleRepository;

        public UserRepository()
        {
            this.roleRepository = new RoleRepository();
        }

        public IList<string> GetRoles(int userId)
        {
            var user = Get(userId);

            return user.Role.Select(x => x.Name).ToList();
        }

        public void DeleteRoles(int userId)
        {
            var user = Get(userId);
            var userRoles = user.Role.ToList();

            foreach (var role in userRoles)
            {
                user.Role.Remove(role);
            }

            Save();
        }

        public void CreateUserRole(int userId, int roleId)
        {
            var user = Get(userId);

            var dbContext = GetContext();

            var role = dbContext.Role.Find(roleId);

            user.Role.Add(role);

            Save();
        }
    }
}