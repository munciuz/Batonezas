using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishCommands
{
    public class CreateDishCommand : CommandBase
    {
        private readonly IDishService dishService;

        public CreateDishCommand(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public DishModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishService.Create(Model);
        }
    }
}