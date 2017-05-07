using System.Web.Http;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleService userService;

        public RoleController(IRoleService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetAll()
        {
            var model = userService.GetList();

            return Ok(model);
        }
    }
}