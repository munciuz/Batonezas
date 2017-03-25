using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
    }

    public class RoleRepository : Repository<Role>, IRoleRepository
    {
    }
}