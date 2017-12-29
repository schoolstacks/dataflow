namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentActionColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "AgentAction", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "AgentAction");
        }
    }
}
