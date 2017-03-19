using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private BatonezasContext context;

        public BatonezasUserStore()
        {
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

        public async Task<User> FindByIdAsync(string userId)
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

        public Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}