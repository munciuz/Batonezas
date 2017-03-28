using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Batonezas.WebApi.BusinessRules.DishTypeCommands;
using Batonezas.WebApi.BusinessRules.TestCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models;

namespace Batonezas.WebApi.Controllers
{
    public class DishTypeController : ApiControllerBase
    {
        [HttpPost]
        public IHttpActionResult Edit(DishTypeModel model)
        {
            return Command<EditDishTypeCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }
    }
}