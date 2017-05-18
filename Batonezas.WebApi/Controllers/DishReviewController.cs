using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishReviewCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models.DishReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class DishReviewController : ApiControllerBase
    {
        private readonly IDishReviewService dishReviewService;

        public DishReviewController(IDishReviewService dishReviewService)
        {
            this.dishReviewService = dishReviewService;
        }

        [HttpGet]
        public IHttpActionResult GetAll(int dishId, int placeId)
        {
            var model = dishReviewService.GetList(new DishReviewListFilterModel { DishId = dishId, PlaceId = placeId });

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = dishReviewService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetList(DishReviewListFilterModel filter)
        {
            var model = dishReviewService.GetList(filter);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetGroupedList(DishReviewListFilterModel filter)
        {
            var model = dishReviewService.GetGroupedList(filter);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetPageModel()
        {
            var model = dishReviewService.GetPageModel();

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
        public IHttpActionResult Edit()
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}