using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Batonezas.DataAccess;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Controllers
{
    public class UserTest
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
    
    public class TestController : ApiController
    {
        private IUserRepository userRepository;

        public TestController()
        {
            userRepository = new UserRepository();
        }

        [HttpGet]
        public IHttpActionResult Test()
        {
            var b = userRepository.CreateQuery().ToList();

            var a = new List<UserTest>();

            using (var c = new BatonezasContext())
            {
                a = c.Users.Select(x => new UserTest
                {
                    Id = x.Id,
                    Name = x.UserName
                }).ToList();
            }

            return Ok(a);
        }
    }
}