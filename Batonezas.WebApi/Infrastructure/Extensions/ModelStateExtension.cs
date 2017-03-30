using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace Batonezas.WebApi.Infrastructure.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddErrors(this ModelStateDictionary stateDictionary, IEnumerable<ErrorInfo> errors)
        {
            foreach (var error in errors)
            {
                var propertyName = !string.IsNullOrEmpty(error.PropertyName) ? error.PropertyName : "model";
                stateDictionary.AddModelError(propertyName, error.ErrorMessage);
            }
        }
    }
}