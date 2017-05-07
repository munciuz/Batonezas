using Batonezas.WebApi.Models.UserModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.UserCommand
{
    public class EditUserCommand : CommandBase
    {
        private readonly IUserService service;

        public EditUserCommand(IUserService service)
        {
            this.service = service;
        }

        public UserEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            service.Edit(Model);
        }
    }
}