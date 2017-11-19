using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataFlow.Web.Startup))]
namespace DataFlow.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
