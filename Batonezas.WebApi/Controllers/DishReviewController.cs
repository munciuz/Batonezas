using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishReviewCommands;
using Batonezas.WebApi.BusinessRules.DishTypeCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Models.DishTypeModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class DishReviewController : ApiControllerBase
    {
        private readonly IDishTypeService dishTypeService;

        public DishReviewController(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = dishTypeService.GetList(new DishTypeListFilterModel());

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = dishTypeService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetList(DishTypeListFilterModel filter)
        {
            var model = dishTypeService.GetList(filter);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(DishReviewEditModel model)
        {
            return Command<CreateDishReviewCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpPost]
        public IHttpActionResult Edit(DishTypeModel model)
        {
            return Command<EditDishTypeCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeleteDishTypeCommand>(
                cmd =>
                {
                    cmd.Id = id;
                },
                cmd => Ok());
        }
    }
}