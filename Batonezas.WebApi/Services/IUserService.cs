using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.WebApi.Models.RoleModels;
using Batonezas.WebApi.Models.UserModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IUserService
    {
        UserEditModel Get(int id);
        IList<UserListItemModel> GetList(UserListFilterModel filter);
        void Edit(UserEditModel model);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, 
            IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public UserEditModel Get(int id)
        {
            var user = userRepository.Get(id);
            var role = user.Role.SingleOrDefault();

            //var model = Mapper.Map<UserEditModel>(user);

            var model = new UserEditModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email
            };

            if (role != null)
            {
                model.Role = new RoleEditModel
                {
                    Id = role.Id,
                    Name = role.Name
                };
            }

            var allRoles = roleRepository.CreateQuery();

            model.AllRoles = allRoles.Select(x => new RoleEditModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray();

            return model;
        }

        public IList<UserListItemModel> GetList(UserListFilterModel filter)
        {
            var users = userRepository.CreateQuery();

            var userList = users.Select(x => new UserListItemModel
            {
                Id = x.Id,
                Username = x.UserName,
                Email = x.Email
            }).ToList();

            return userList;
        }

        public void Edit(UserEditModel model)
        {
            userRepository.DeleteRoles(model.Id);

            userRepository.CreateUserRole(model.Id, model.Role.Id);
        }
    }
}