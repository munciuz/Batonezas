using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.PlaceCommands
{
    public class EditPlaceCommand : CommandBase
    {
        private readonly IPlaceService placeService;

        public EditPlaceCommand(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public PlaceEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            placeService.Edit(Model);
        }
    }
}