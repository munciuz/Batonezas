using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Batonezas.DataAccess;
using Batonezas.WebApi.Repositories;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasUserStore : IUserStore<User, int>, IUserPasswordStore<User, int>, IUserRoleStore<User, int>
    {
        private BatonezasContext context;
        private IUserRepository userRepository;

        public BatonezasUserStore()
        {
            //this.userRepository = new UserRepository();
            //context = new BatonezasContext();
        }

        public void Dispose()
        {
            //context.Dispose();
        }

        public Task CreateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            User user = await context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var result = await context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

            return result;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(User user)
        {
            return await Task.FromResult<bool>(!String.IsNullOrEmpty(user.PasswordHash));
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetRoles(User user)
        {
            return user.Role.Select(x => x.Name).ToList();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}