using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasUserManager : UserManager<User, int>
    {
        public BatonezasUserManager(IUserStore<User, int> store) : base(store)
        {
        }
    }
}