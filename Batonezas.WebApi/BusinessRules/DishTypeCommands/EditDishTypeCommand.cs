using Batonezas.WebApi.Models.DishTypeModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishTypeCommands
{
    public class CreateDishTypeCommand : CommandBase
    {
        private readonly IDishTypeService dishTypeService;

        public CreateDishTypeCommand(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        public DishTypeModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishTypeService.Create(Model);
        }
    }
}