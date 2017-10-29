
using System.Reflection;
using System.Web.Http;
using LightInject;
namespace BestPetSite.WebApi
{
    public partial class Startup
    {
        public void ConfigureInjector(HttpConfiguration config)
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("BestPetSite.Repository*.dll");
            container.RegisterAssembly("BestPetSite.UnitOfWork*.dll");
            
            container.RegisterApiControllers();
            container.EnableWebApi(config);
        }
    }
}