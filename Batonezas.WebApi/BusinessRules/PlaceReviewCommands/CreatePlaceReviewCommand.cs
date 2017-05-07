using Batonezas.WebApi.Models.PlaceReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.PlaceReviewCommands
{
    public class CreatePlaceReviewCommand : CommandBase
    {
        private readonly IPlaceReviewService placeReviewService;

        public CreatePlaceReviewCommand(IPlaceReviewService placeReviewService)
        {
            this.placeReviewService = placeReviewService;
        }

        public PlaceReviewEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            placeReviewService.Create(Model);
        }
    }
}