using Batonezas.WebApi.Models.RoleModels;

namespace Batonezas.WebApi.Models.UserModels
{
    public class UserEditModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public RoleEditModel Role { get; set; }

        public RoleEditModel[] AllRoles { get; set; }
    }
}