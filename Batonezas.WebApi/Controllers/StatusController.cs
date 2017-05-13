using System.Web.Http;

namespace Batonezas.WebApi.Controllers
{
    public class StatusController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(1);
        }
    }
}