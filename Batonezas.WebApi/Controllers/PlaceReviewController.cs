using System.Web.Http;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models;
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
    }
}