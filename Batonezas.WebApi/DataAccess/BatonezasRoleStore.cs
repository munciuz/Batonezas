using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasRoleStore : IRoleStore<Role, int>
    {
        public void Dispose()
        {
            var a = 2;
            //throw new NotImplementedException();
        }

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}