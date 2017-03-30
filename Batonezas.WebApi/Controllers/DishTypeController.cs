using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishTypeCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class DishTypeController : ApiControllerBase
    {
        private IDishTypeService dishTypeService;

        public DishTypeController(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = dishTypeService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetList(DishTypeListFilter filter)
        {
            var model = dishTypeService.GetList(filter);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(DishTypeModel model)
        {
            return Command<CreateDishTypeCommand>(
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