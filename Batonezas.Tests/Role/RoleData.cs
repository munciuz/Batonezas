using System.Collections.Generic;
using System.Linq;

namespace Batonezas.Tests.Role
{
    public static class RoleData
    {
        public static IQueryable<DataAccess.Role> CreateQuery()
        {
            IList<DataAccess.Role> list = new List<DataAccess.Role>
            {
                new DataAccess.Role {Id = 1, Name = "admin"},
                new DataAccess.Role {Id = 2, Name = "user"}
            };

            var roles = list.AsQueryable();

            return roles;
        }
    }
}
