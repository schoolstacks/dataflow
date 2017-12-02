using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Common.Services;
using DataFlow.Web.Services;
using NLog;

namespace DataFlow.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<DataFlowDbContext>().InstancePerRequest();
            builder.RegisterType<EdFiService>().InstancePerRequest();
            builder.RegisterType<EdFiMetadataProcessor>().InstancePerRequest();
            builder.Register(c => LogManager.GetLogger("DataFlow.Web")).As<ILogger>().InstancePerRequest();
            builder.RegisterType<NLogService>().AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
