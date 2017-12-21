namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentDbSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dataflow.Agent", newSchema: "dbo");
            MoveTable(name: "dataflow.AgentSchedule", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.AgentSchedule", newSchema: "dataflow");
            MoveTable(name: "dbo.Agent", newSchema: "dataflow");
        }
    }
}
