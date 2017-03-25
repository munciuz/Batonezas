using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Batonezas.DataAccess
{
    public partial class User : IdentityUser, IUser<int>, IBatonezasEntity //IdentityUser<int, UserLogin, Role, UserClaim>, IUser<int>, IBatonezasEntity
    {
    }
}
