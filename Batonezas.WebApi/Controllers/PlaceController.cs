using System.Web.Http;
using Batonezas.WebApi.BusinessRules.PlaceCommands;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Services;

namespace Batonezas.WebApi.Controllers
{
    public class PlaceController : ApiControllerBase
    {
        private readonly IPlaceService placeService;

        public PlaceController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = placeService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetList(PlaceListFilterModel filter)
        {
            var model = placeService.GetList(filter);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetPlaceTypes()
        {
            var result = placeService.GetPlaceTypes();

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create(PlaceEditModel model)
        {
            return Command<CreatePlaceCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpPost]
        public IHttpActionResult Edit(PlaceEditModel model)
        {
            return Command<EditPlaceCommand>(
                cmd =>
                {
                    cmd.Model = model;
                },
                cmd => Ok(cmd.Model.Id));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Command<DeletePlaceCommand>(
                cmd =>
                {
                    cmd.Id = id;
                },
                cmd => Ok());
        }
    }
}