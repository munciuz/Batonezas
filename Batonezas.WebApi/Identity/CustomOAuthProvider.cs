using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Batonezas.DataAccess;
using Batonezas.WebApi.DataAccess;
using Batonezas.WebApi.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Batonezas.WebApi.Identity
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private BatonezasUserStore batonezasUserStore;
        private readonly IUserRepository userRepository;

        public CustomOAuthProvider()
        {
            userRepository = new UserRepository();
            batonezasUserStore = new BatonezasUserStore();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = context.OwinContext.Get<BatonezasContext>().Users.FirstOrDefault(u => u.UserName == context.UserName);

            if (!context.OwinContext.Get<BatonezasUserManager>().CheckPassword(user, context.Password))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                context.Rejected();
                return Task.FromResult<object>(null);
            }

            var ticket = new AuthenticationTicket(SetClaimsIdentity(context, user), new AuthenticationProperties());
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, User user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            
            var urep = new UserRepository();
            var userRoles = urep.GetRoles(user.Id);

            //var userRoles = context.OwinContext.Get<BatonezasUserManager>().GetRoles(user.Id);
            foreach (var role in userRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }
    }
}