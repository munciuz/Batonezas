using System.Data.Entity;
using System.Web.Http;
using System.Web.Optimization;
using Batonezas.WebApi.DataAccess;
using Batonezas.WebApi.Infrastructure.ObjectMappings;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Batonezas.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Database.SetInitializer(new Initializer());
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            AutoMapperConfiguration.Configure();
        }
    }
}
