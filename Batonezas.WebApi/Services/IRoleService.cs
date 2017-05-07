using System.Collections.Generic;
using System.Linq;
using Batonezas.WebApi.Models.RoleModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IRoleService
    {
        IList<RoleEditModel> GetList();
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IList<RoleEditModel> GetList()
        {
            var roles = roleRepository.CreateQuery();

            var rolesList = roles.Select(x => new RoleEditModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray();

            return rolesList;
        }
    }
}