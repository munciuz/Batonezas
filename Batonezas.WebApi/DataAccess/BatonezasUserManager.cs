using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasUserManager : UserManager<User>
    {
        public BatonezasUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}