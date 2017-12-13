using System.Web.Http;

namespace DataFlow.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
        }
    }
}