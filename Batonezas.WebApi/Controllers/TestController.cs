using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Controllers
{
    public class UserTest
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
    
    public class TestController : ApiController
    {
        [HttpGet]
        //[Authorize]
        public IHttpActionResult Test()
        {
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