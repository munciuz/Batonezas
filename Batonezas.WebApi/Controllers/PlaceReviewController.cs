using System.Web.Http;
using Batonezas.WebApi.BusinessRules.ReviewCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.ReviewModels;
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
    }
}