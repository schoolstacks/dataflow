using Microsoft.Owin;
using Owin;
using DataFlow.Common.Migrations;
using System.Data.Entity.Migrations;

[assembly: OwinStartupAttribute(typeof(DataFlow.Web.Startup))]
namespace DataFlow.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Auto-migrate the DataFlow.Common entity model to the database
            Configuration config = new Configuration();
            DbMigrator migrator = new DbMigrator(config);
            migrator.Update();

            ConfigureAuth(app);
        }
    }
}
