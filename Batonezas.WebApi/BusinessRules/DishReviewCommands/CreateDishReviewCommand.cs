using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishReviewCommands
{
    public class CreateDishReviewCommand : CommandBase
    {
        private readonly IDishReviewService dishReviewService;

        public CreateDishReviewCommand(IDishReviewService dishReviewService)
        {
            this.dishReviewService = dishReviewService;
        }

        public DishReviewEditModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishReviewService.Create(Model);
        }
    }
}