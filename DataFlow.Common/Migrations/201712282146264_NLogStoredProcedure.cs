namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NLogStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.NLog_AddEntry",
                p => new
                {
                    machineName = p.String(maxLength: 200, fixedLength: false, unicode: true),
                    siteName = p.String(maxLength: 200, fixedLength: false, unicode: true),
                    logged = p.DateTime(),
                    level = p.String(maxLength: 5, fixedLength: false, unicode: false),
                    userName = p.String(maxLength: 200, fixedLength: false, unicode: true),
                    message = p.String(maxLength: null, fixedLength: null, unicode: true),
                    logger = p.String(maxLength: 300, fixedLength: false, unicode: true),
                    properties = p.String(maxLength: null, fixedLength: false, unicode: true),
                    serverName = p.String(maxLength: 200, fixedLength: false, unicode: true),
                    port = p.String(maxLength: 100, fixedLength: false, unicode: true),
                    url = p.String(maxLength: 2000, fixedLength: false, unicode: true),
                    https = p.Boolean(),
                    serverAddress = p.String(maxLength: 100, fixedLength: false, unicode: true),
                    remoteAddress = p.String(maxLength: 100, fixedLength: false, unicode: true),
                    callSite = p.String(maxLength: 300, fixedLength: false, unicode: true),
                    exception = p.String(maxLength: null, fixedLength: false, unicode: true)
                },
                body:
                @"INSERT INTO [dbo].[NLog] (
                        [MachineName],
                        [SiteName],
                        [Logged],
                        [Level],
                        [UserName],
                        [Message],
                        [Logger],
                        [Properties],
                        [ServerName],
                        [Port],
                        [Url],
                        [Https],
                        [ServerAddress],
                        [RemoteAddress],
                        [CallSite],
                        [Exception]
                      ) VALUES (
                        @machineName,
                        @siteName,
                        @logged,
                        @level,
                        @userName,
                        @message,
                        @logger,
                        @properties,
                        @serverName,
                        @port,
                        @url,
                        @https,
                        @serverAddress,
                        @remoteAddress,
                        @callSite,
                        @exception
                      );"
            );
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.NLog_AddEntry");
        }
    }
}
