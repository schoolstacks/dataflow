using Microsoft.Owin;
using Owin;
using DataFlow.Common.Migrations;
using DataFlow.Common.DAL;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Authentication;

[assembly: OwinStartupAttribute(typeof(DataFlow.Web.Startup))]
namespace DataFlow.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Check to see if the default database exists, if not, create it
            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                bool exists = ctx.Database
                     .SqlQuery<int?>(@"
                                     SELECT 1 FROM sys.tables AS T
                                     INNER JOIN sys.schemas AS S ON T.schema_id = S.schema_id
                                     WHERE S.Name = 'dbo' AND T.Name = 'Agents'")
                     .SingleOrDefault() != null;

                Configuration config = new Configuration();

                if (!exists)
                {
                    // Auto-migrate the DataFlow.Common entity model to the database

                    DbMigrator migrator = new DbMigrator(config);
                    migrator.Update();

                }

                if (ctx.Entities.Count() == 0 || ctx.EdfiDictionary.Count() == 0 || ctx.FileStatuses.Count() == 0)
                {
                    config.ForceSeed(ctx);
                }

            }



            ConfigureAuth(app);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
