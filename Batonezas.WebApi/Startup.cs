using System.Web.Http.Cors;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Batonezas.WebApi.Startup))]

namespace Batonezas.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.userco(cors);

            ConfigureOAuth(app);
        }
    }
}
