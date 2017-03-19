using System.Web.Http;

namespace Batonezas.WebApi
{
    public class FilterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}