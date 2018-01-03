namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentChromeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentAgentChromes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        AgentChromeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.AgentChromes", t => t.AgentChromeId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.AgentChromeId);
            
            CreateTable(
                "dbo.AgentChromes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentUuid = c.Guid(nullable: false),
                        AccessToken = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgentAgentChromes", "AgentChromeId", "dbo.AgentChromes");
            DropForeignKey("dbo.AgentAgentChromes", "AgentId", "dbo.Agents");
            DropIndex("dbo.AgentAgentChromes", new[] { "AgentChromeId" });
            DropIndex("dbo.AgentAgentChromes", new[] { "AgentId" });
            DropTable("dbo.AgentChromes");
            DropTable("dbo.AgentAgentChromes");
        }
    }
}
