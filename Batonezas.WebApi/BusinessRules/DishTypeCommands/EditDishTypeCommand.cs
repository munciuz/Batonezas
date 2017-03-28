using Batonezas.WebApi.Models;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishTypeCommands
{
    public class EditDishTypeCommand : CommandBase
    {
        private readonly IDishTypeService dishTypeService;

        public EditDishTypeCommand(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        public DishTypeModel Model { get; set; }

        protected override void ExecuteCommand()
        {
            dishTypeService.Edit(Model);
        }
    }
}