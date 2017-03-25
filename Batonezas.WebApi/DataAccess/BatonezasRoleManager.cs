using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasRoleManager : RoleManager<Role, int>
    {
        public BatonezasRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}