using System.Web.Http;
using Batonezas.WebApi.BusinessRules.TagCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class TagController : ApiControllerBase
    {
        private readonly ITagService dishService;

        public TagController(ITagService dishService)
        {
            this.dishService = dishService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = dishService.Get(id);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetAll(TagListFilterModel filter)
        {
            var model = dishService.GetList(filter);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(TagEditModel model)
        {
            return Command<CreateTagCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpPost]
        public IHttpActionResult Edit(TagEditModel model)
        {
            return Command<EditTagCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeleteTagCommand>(
                cmd =>
                {
                    cmd.Id = id;
                },
                cmd => Ok());
        }
    }
}