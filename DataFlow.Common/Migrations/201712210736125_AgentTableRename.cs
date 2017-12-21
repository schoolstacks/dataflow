namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentTableRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dataflow.agent_schedule", newName: "AgentSchedule");
            DropIndex("dataflow.AgentSchedule", new[] { "AgentID" });
            CreateIndex("dataflow.AgentSchedule", "AgentId");
        }
        
        public override void Down()
        {
            DropIndex("dataflow.AgentSchedule", new[] { "AgentId" });
            CreateIndex("dataflow.AgentSchedule", "AgentID");
            RenameTable(name: "dataflow.AgentSchedule", newName: "agent_schedule");
        }
    }
}
