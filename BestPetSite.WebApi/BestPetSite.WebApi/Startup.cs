using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;
namespace BestPetSite.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            Register(config);
            ConfigureOAuth(app);
            ConfigureInjector(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}
