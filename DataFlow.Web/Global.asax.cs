using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extras.AggregateService;
using Autofac.Integration.Mvc;
using CacheManager.Core;
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
            

            /*
             * Turning on HTTPS locally without properly setting up the DataFlow.Web project
             * can result in webpage timeouts and redirect errors. To have Https work locally,
             * go to the project properties and change "SSL Enabled" from False to True.
             * Take note of the SSL URL that is then generated. Now, right click on DataFlow.Web
             * and go to Properties and then navigate to the Web tab and enter the SSL URL
             * for Project URL.
             */
            if (Request.IsLocal == false)
            {
                var forceHttps = Convert.ToBoolean(ConfigurationManager.AppSettings["ForceHttps"] ?? "false");

                if (forceHttps)
                    GlobalFilters.Filters.Add(new RequireHttpsAttribute());
            }

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
            builder.RegisterModule(new AutoMapperModule());
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

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
