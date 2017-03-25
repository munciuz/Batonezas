using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Batonezas.DataAccess
{
    public partial class Role : IdentityUserRole<int>, IRole<int>, IBatonezasEntity
    {
    }
}
