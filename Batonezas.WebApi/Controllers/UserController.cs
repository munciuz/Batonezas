using System.Web.Http;
using Batonezas.WebApi.BusinessRules.UserCommand;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.UserModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = userService.Get(id);

            return Ok(model);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetAll(UserListFilterModel filter)
        {
            var model = userService.GetList(filter);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Edit(UserEditModel model)
        {
            return Command<EditUserCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUserProfile()
        {
            var model = userService.GetUserProfile();

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult EditUserProfile(UserProfileEditModel model)
        {
            return Command<EditUserProfileCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }
    }
}