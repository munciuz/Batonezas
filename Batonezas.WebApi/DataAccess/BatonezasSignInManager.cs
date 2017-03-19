using Batonezas.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Batonezas.WebApi.DataAccess
{
    public class BatonezasSignInManager : SignInManager<User, string>
    {
        public BatonezasSignInManager(UserManager<User, string> userManager,
            IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}