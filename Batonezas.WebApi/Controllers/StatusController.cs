using System.Web.Http;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class StatusController : ApiController
    {
        private readonly IImageService imageService;

        public StatusController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            imageService.DeleteImage(6);

            return Ok(1);
        }
    }
}