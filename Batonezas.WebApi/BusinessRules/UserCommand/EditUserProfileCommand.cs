using Batonezas.WebApi.Models.UserModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.UserCommand
{
    public class EditUserProfileCommand : CommandBase
    {
        private readonly IUserService service;

        public EditUserProfileCommand(IUserService service)
        {
            this.service = service;
        }

        public UserProfileEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            service.EditUserProfile(Model);
        }
    }
}