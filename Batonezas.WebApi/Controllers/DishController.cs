using System.Web;
using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Services;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.Controllers
{
    public class DishController : ApiControllerBase
    {
        private readonly IDishService dishService;

        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = dishService.Get(id);

            return Ok(model);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAll(DishListFilterModel filter)
        {
            var model = dishService.GetList(filter);

            var userId = UserHelper.GetCurrentUserId();

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(DishEditModel model)
        {
            return Command<CreateDishCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpPost]
        public IHttpActionResult Edit(DishEditModel model)
        {
            return Command<EditDishCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeleteDishCommand>(
                cmd =>
                {
                    cmd.Id = id;
                },
                cmd => Ok());
        }
    }
}