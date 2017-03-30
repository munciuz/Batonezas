using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishTypeCommands
{
    public class DeleteDishTypeCommand : CommandBase
    {
        private readonly IDishTypeService dishTypeService;

        public DeleteDishTypeCommand(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            dishTypeService.Delete(Id);
        }
    }
}