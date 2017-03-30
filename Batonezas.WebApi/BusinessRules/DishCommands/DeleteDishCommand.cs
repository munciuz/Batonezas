using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.BusinessRules.DishCommands
{
    public class DeleteDishCommand : CommandBase
    {
        private readonly IDishService dishService;

        public DeleteDishCommand(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public int Id { get; set; }

        protected override void ExecuteCommand()
        {
            dishService.Delete(Id);
        }
    }
}