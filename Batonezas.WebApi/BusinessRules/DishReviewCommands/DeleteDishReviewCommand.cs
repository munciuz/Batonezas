using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishReviewCommands
{
    public class DeleteDishReviewCommand : CommandBase
    {
        private readonly IDishReviewService dishReviewService;

        public DeleteDishReviewCommand(IDishReviewService dishReviewService)
        {
            this.dishReviewService = dishReviewService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            dishReviewService.Delete(Id);
        }
    }
}