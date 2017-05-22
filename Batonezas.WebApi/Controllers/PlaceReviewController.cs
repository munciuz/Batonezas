using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishReviewCommands;
using Batonezas.WebApi.BusinessRules.PlaceReviewCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.PlaceReviewModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class PlaceReviewController : ApiControllerBase
    {
        private readonly IPlaceReviewService placeReviewService;

        public PlaceReviewController(IPlaceReviewService placeReviewService)
        {
            this.placeReviewService = placeReviewService;
        }

        public IHttpActionResult GetPlace(int id)
        {
            var model = placeReviewService.GetPlace(id);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetGroupedList(PlaceReviewListFilterModel filter)
        {
            var model = placeReviewService.GetGroupedList(filter);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetPageModel()
        {
            var model = placeReviewService.GetPageModel();

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetReviews(int placeId)
        {
            var model = placeReviewService.GetList(new PlaceReviewListFilterModel { PlaceId = placeId });

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(PlaceReviewEditModel model)
        {
            return Command<CreatePlaceReviewCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeleteDishReviewCommand>(
                cmd => cmd.Id = id,
                cmd => Ok(true));
        }
    }
}