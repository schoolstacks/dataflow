using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extras.AggregateService;
using Autofac.Integration.Mvc;
using CacheManager.Core;
using CacheManager.SystemRuntimeCaching;
using DataFlow.Common.DAL;
using DataFlow.Common.Services;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;
using NLog;

namespace DataFlow.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var appName = ConfigurationManager.AppSettings["AppName"] ?? string.Empty;

            var cacheConfig = ConfigurationBuilder.BuildConfiguration(appName, settings =>
            {
                settings.WithUpdateMode(CacheUpdateMode.None)
                    .WithSystemRuntimeCacheHandle(appName)
                    .EnableStatistics()
                    .EnablePerformanceCounters()
                    .WithExpiration(ExpirationMode.Sliding, TimeSpan.FromHours(2));
            });
            var cacheFactory = CacheFactory.FromConfiguration<string>(appName, cacheConfig);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAggregateService<IBaseServices>();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<DataFlowDbContext>().InstancePerRequest();
            builder.RegisterType<EdFiService>().InstancePerRequest();
            builder.RegisterType<EdFiMetadataProcessor>().InstancePerRequest();
            builder.RegisterType<ConfigurationService>().AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => LogManager.GetLogger(appName)).As<ILogger>().InstancePerRequest();
            builder.RegisterType<NLogService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<WebConfigAppSettingsService>().AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<CacheService>().WithParameters(new[]
            {
                new TypedParameter(typeof(ICacheManagerConfiguration), cacheConfig),
                new TypedParameter(typeof(ICacheManager<string>), cacheFactory)
            }).As<ICacheService>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
