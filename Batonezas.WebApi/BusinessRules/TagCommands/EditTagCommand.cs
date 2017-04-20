using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.TagCommands
{
    public class EditTagCommand : CommandBase
    {
        private readonly ITagService service;

        public EditTagCommand(ITagService service)
        {
            this.service = service;
        }

        public TagEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            service.Edit(Model);
        }
    }
}