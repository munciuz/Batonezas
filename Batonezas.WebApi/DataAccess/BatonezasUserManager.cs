using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasUserManager : UserManager<User>
    {
        public BatonezasUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}