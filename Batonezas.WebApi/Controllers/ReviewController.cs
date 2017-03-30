using System.Web.Http;
using Batonezas.WebApi.BusinessRules.ReviewCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.ReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class ReviewController : ApiControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = reviewService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetList(ReviewListFilterModel filter)
        {
            var model = reviewService.GetList(filter);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(ReviewEditModel model)
        {
            return Command<CreateReviewCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpPost]
        public IHttpActionResult Edit(ReviewEditModel model)
        {
            return Command<EditReviewCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeleteReviewCommand>(
                cmd =>
                {
                    cmd.Id = id;
                },
                cmd => Ok());
        }
    }
}