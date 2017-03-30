using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishCommands
{
    public class EditDishCommand : CommandBase
    {
        private readonly IDishService dishService;

        public EditDishCommand(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public DishModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishService.Edit(Model);
        }
    }
}