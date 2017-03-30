using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.PlaceCommands
{
    public class DeletePlaceCommand : CommandBase
    {
        private readonly IPlaceService placeService;

        public DeletePlaceCommand(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            placeService.Delete(Id);
        }
    }
}