using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Batonezas.DataAccess;
using Batonezas.WebApi.BusinessRules.TestCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Controllers
{
    public class UserTest
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
    
    public class TestController : ApiControllerBase
    {
        private readonly IUserRepository userRepository;

        public TestController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet]
        public IHttpActionResult Test()
        {
            return Command<TestCommand>(
                cmd =>
                {
                    cmd.b = 3;
                },
                cmd => Ok(cmd.result));
        }
    }
}