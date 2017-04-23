using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishReviewCommands;
using Batonezas.WebApi.Infrastructure;
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
        public IHttpActionResult GetAll()
        {
            var model = dishReviewService.GetList(new DishReviewListFilterModel());

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult GetList(DishReviewListFilterModel filter)
        {
            var model = dishReviewService.GetList(filter);

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