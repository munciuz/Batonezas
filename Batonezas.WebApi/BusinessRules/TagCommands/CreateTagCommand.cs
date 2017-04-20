using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.TagCommands
{
    public class CreateTagCommand : CommandBase
    {
        private readonly ITagService dishService;

        public CreateTagCommand(ITagService dishService)
        {
            this.dishService = dishService;
        }

        public TagEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishService.Create(Model);
        }
    }
}