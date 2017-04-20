using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.TagCommands
{
    public class DeleteTagCommand : CommandBase
    {
        private readonly ITagService service;

        public DeleteTagCommand(ITagService service)
        {
            this.service = service;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            service.Delete(Id);
        }
    }
}