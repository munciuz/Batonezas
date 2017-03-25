using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasSignInManager : SignInManager<User, int>
    {
        public BatonezasSignInManager(UserManager<User, int> userManager,
            IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}