namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManualDataMap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataMaps", "Manual", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataMaps", "Manual");
        }
    }
}
