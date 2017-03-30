using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Batonezas.WebApi.Infrastructure;

namespace Batonezas.WebApi.Controllers
{
    public class ReviewController : ApiControllerBase
    {
        public IHttpActionResult Create()
        {
            throw new RulesException();
        }
    }
}