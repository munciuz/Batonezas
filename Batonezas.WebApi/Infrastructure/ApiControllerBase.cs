using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Batonezas.WebApi.BusinessRules;
using Batonezas.WebApi.Infrastructure.Extensions;
using Microsoft.Practices.Unity;

namespace Batonezas.WebApi.Infrastructure
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IHttpActionResult Command<TCommand>(Action<TCommand> initCommand, Func<TCommand, IHttpActionResult> success)
            where TCommand : ICommand
        {
            HttpError error;
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var command = (TCommand) UnityConfig.Container.Resolve(typeof(TCommand));

                initCommand(command);
                command.Execute();

                return success(command);
            }
            catch (RulesException ex)
            {
                ModelState.AddErrors(ex.Errors);
                error = new HttpError(ModelState, false);
            }
            catch (Exception e)
            {
                // need to log errors
                error = new HttpError(e, true);
            }

            var responseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            return ResponseMessage(responseMessage);
        }
    }
}