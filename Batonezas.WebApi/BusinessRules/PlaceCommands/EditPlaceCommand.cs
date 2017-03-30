using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.PlaceCommands
{
    public class CreatePlaceCommand : CommandBase
    {
        private readonly IPlaceService placeService;

        public CreatePlaceCommand(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public PlaceEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            placeService.Create(Model);
        }
    }
}