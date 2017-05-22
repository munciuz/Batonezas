using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishReviewCommands
{
    public class DeletePlaceReviewCommand : CommandBase
    {
        private readonly IPlaceReviewService placeReviewService;

        public DeletePlaceReviewCommand(IPlaceReviewService placeReviewService)
        {
            this.placeReviewService = placeReviewService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            placeReviewService.Delete(Id);
        }
    }
}