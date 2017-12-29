namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAgentRequiredValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agents", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Agents", "AgentTypeCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Agents", "Url", c => c.String());
            AlterColumn("dbo.Agents", "Username", c => c.String());
            AlterColumn("dbo.Agents", "Password", c => c.String());
            AlterColumn("dbo.Agents", "Directory", c => c.String());
            AlterColumn("dbo.Agents", "FilePattern", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agents", "FilePattern", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Directory", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "AgentTypeCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Agents", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
