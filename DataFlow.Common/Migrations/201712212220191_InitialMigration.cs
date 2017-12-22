namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AgentTypeCode = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Directory = c.String(nullable: false),
                        FilePattern = c.String(nullable: false),
                        Queue = c.Guid(nullable: false),
                        Custom = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastExecuted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgentSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.DataMapAgents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataMapId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                        ProcessingOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.DataMaps", t => t.DataMapId, cascadeDelete: true)
                .Index(t => t.DataMapId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.DataMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        EntityId = c.Int(nullable: false),
                        Map = c.String(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Metadata = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BootstrapDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        Data = c.String(nullable: false),
                        ProcessingOrder = c.Int(nullable: false),
                        ProcessedDate = c.DateTime(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        Url = c.String(),
                        AgentId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        Message = c.String(),
                        Rows = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.FileStatus", t => t.Status, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.Status);
            
            CreateTable(
                "dbo.FileStatus",
                c => new
                    {
                        Value = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Value);
            
            CreateTable(
                "dbo.LogIngestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationOrganizationId = c.Guid(),
                        Level = c.String(maxLength: 255),
                        Operation = c.String(maxLength: 255),
                        AgentId = c.Int(),
                        Process = c.String(),
                        FileName = c.String(),
                        Result = c.String(maxLength: 255),
                        Message = c.String(),
                        RecordCount = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 255),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.EdfiDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupSet = c.String(nullable: false, maxLength: 255),
                        OriginalValue = c.String(nullable: false, maxLength: 255),
                        DisplayValue = c.String(nullable: false, maxLength: 255),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lookups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupSet = c.String(nullable: false, maxLength: 1024),
                        Key = c.String(nullable: false, maxLength: 1024),
                        Value = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineName = c.String(maxLength: 200),
                        SiteName = c.String(maxLength: 200),
                        Logged = c.DateTime(nullable: false),
                        Level = c.String(nullable: false, maxLength: 5),
                        UserName = c.String(maxLength: 200),
                        Message = c.String(),
                        Logger = c.String(maxLength: 300),
                        Properties = c.String(),
                        ServerName = c.String(maxLength: 200),
                        Port = c.String(maxLength: 100),
                        Url = c.String(maxLength: 2000),
                        Https = c.Boolean(),
                        ServerAddress = c.String(maxLength: 100),
                        RemoteAddress = c.String(),
                        Callsite = c.String(maxLength: 300),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Guid(nullable: false),
                        EntityType = c.String(nullable: false, maxLength: 255),
                        TermDescriptorId = c.Int(),
                        SchoolYear = c.Short(),
                        Measure = c.String(nullable: false, maxLength: 255),
                        ValueInt = c.Int(),
                        ValueDecimal = c.Decimal(precision: 18, scale: 2),
                        ValueVarchar = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LogIngestions", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Files", "Status", "dbo.FileStatus");
            DropForeignKey("dbo.Files", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.DataMaps", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.BootstrapDatas", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DataMapAgents", "DataMapId", "dbo.DataMaps");
            DropForeignKey("dbo.DataMapAgents", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.AgentSchedules", "AgentId", "dbo.Agents");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LogIngestions", new[] { "AgentId" });
            DropIndex("dbo.Files", new[] { "Status" });
            DropIndex("dbo.Files", new[] { "AgentId" });
            DropIndex("dbo.BootstrapDatas", new[] { "EntityId" });
            DropIndex("dbo.DataMaps", new[] { "EntityId" });
            DropIndex("dbo.DataMapAgents", new[] { "AgentId" });
            DropIndex("dbo.DataMapAgents", new[] { "DataMapId" });
            DropIndex("dbo.AgentSchedules", new[] { "AgentId" });
            DropTable("dbo.Statistics");
            DropTable("dbo.NLog");
            DropTable("dbo.Lookups");
            DropTable("dbo.EdfiDictionaries");
            DropTable("dbo.Configurations");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LogIngestions");
            DropTable("dbo.FileStatus");
            DropTable("dbo.Files");
            DropTable("dbo.BootstrapDatas");
            DropTable("dbo.Entities");
            DropTable("dbo.DataMaps");
            DropTable("dbo.DataMapAgents");
            DropTable("dbo.AgentSchedules");
            DropTable("dbo.Agents");
        }
    }
}
