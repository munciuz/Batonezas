using System.Linq;
using System.Web;
using Batonezas.DataAccess;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Infrastructure.Helpers
{
    public static class UserHelper
    {
        public static User GetCurrentUser()
        {
            IRepository<User> repository = new UserRepository();

            var username = HttpContext.Current.User.Identity.Name;

            var user = repository.CreateQuery().SingleOrDefault(x => x.UserName == username);

            return user;
        }

        public static int GetCurrentUserId()
        {
            var user = GetCurrentUser();

            return user?.Id ?? 1;
        }
    }
}