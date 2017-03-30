using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.ReviewCommands
{
    public class DeleteReviewCommand : CommandBase
    {
        private readonly IReviewService reviewService;

        public DeleteReviewCommand(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            reviewService.Delete(Id);
        }
    }
}