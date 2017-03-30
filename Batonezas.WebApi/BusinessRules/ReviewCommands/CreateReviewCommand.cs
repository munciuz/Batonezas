using Batonezas.WebApi.Models.ReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.ReviewCommands
{
    public class EditReviewCommand : CommandBase
    {
        private readonly IReviewService reviewService;

        public EditReviewCommand(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public ReviewEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            reviewService.Edit(Model);
        }
    }
}