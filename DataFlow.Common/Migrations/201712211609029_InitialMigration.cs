namespace DataFlow.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agent",
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
                "dbo.AgentSchedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.DataMapAgent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataMapId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                        ProcessingOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.DataMap", t => t.DataMapId, cascadeDelete: true)
                .Index(t => t.DataMapId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.DataMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                        EntityId = c.Int(nullable: false),
                        Map = c.String(nullable: false, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Entity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                        URL = c.String(unicode: false),
                        Metadata = c.String(unicode: false),
                        CreateDate = c.DateTime(storeType: "date"),
                        UpdateDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BootstrapData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        Data = c.String(nullable: false, unicode: false),
                        ProcessingOrder = c.Int(nullable: false),
                        ProcessedDate = c.DateTime(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, unicode: false),
                        Url = c.String(),
                        AgentId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255, unicode: false),
                        Message = c.String(unicode: false),
                        Rows = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.FileStatus", t => t.Status, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.Status);
            
            CreateTable(
                "dbo.FileStatus",
                c => new
                    {
                        Value = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Value);
            
            CreateTable(
                "dbo.LogIngestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationOrganizationId = c.Guid(),
                        Level = c.String(nullable: false, maxLength: 255, unicode: false),
                        Operation = c.String(nullable: false, maxLength: 255, unicode: false),
                        AgentId = c.Int(nullable: false),
                        Process = c.String(nullable: false, unicode: false),
                        FileName = c.String(),
                        Result = c.String(nullable: false, maxLength: 255, unicode: false),
                        Message = c.String(unicode: false),
                        RecordCount = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
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
                "dbo.Configuration",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 255),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.EdFiDictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupSet = c.String(nullable: false, maxLength: 50, unicode: false),
                        OriginalValue = c.String(nullable: false, maxLength: 50, unicode: false),
                        DisplayValue = c.String(nullable: false, maxLength: 50, unicode: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Thread = c.String(nullable: false, maxLength: 255, unicode: false),
                        Level = c.String(nullable: false, maxLength: 50, unicode: false),
                        Logger = c.String(nullable: false, maxLength: 255, unicode: false),
                        Message = c.String(nullable: false, maxLength: 4000, unicode: false),
                        Exception = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lookup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupSet = c.String(nullable: false, maxLength: 1024, unicode: false),
                        Key = c.String(nullable: false, maxLength: 1024, unicode: false),
                        Value = c.String(nullable: false, maxLength: 1024, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcessedData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Base64HashedString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statistic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Guid(nullable: false),
                        EntityType = c.String(nullable: false, maxLength: 255, unicode: false),
                        TermDescriptorId = c.Int(),
                        SchoolYear = c.Short(),
                        Measure = c.String(nullable: false, maxLength: 255, unicode: false),
                        ValueInt = c.Int(),
                        ValueDecimal = c.Decimal(precision: 18, scale: 2),
                        ValueVarchar = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineName = c.String(nullable: false, maxLength: 200),
                        SiteName = c.String(nullable: false, maxLength: 200),
                        Logged = c.DateTime(nullable: false),
                        Level = c.String(nullable: false, maxLength: 5),
                        UserName = c.String(maxLength: 200),
                        Message = c.String(nullable: false),
                        Logger = c.String(maxLength: 300),
                        Properties = c.String(),
                        ServerName = c.String(maxLength: 200),
                        Port = c.String(maxLength: 100),
                        Url = c.String(maxLength: 2000),
                        Https = c.Boolean(),
                        ServerAddress = c.String(maxLength: 100),
                        RemoteAddress = c.String(maxLength: 100),
                        Callsite = c.String(maxLength: 300),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LogIngestion", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.File", "Status", "dbo.FileStatus");
            DropForeignKey("dbo.File", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.DataMapAgent", "DataMapId", "dbo.DataMap");
            DropForeignKey("dbo.DataMap", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.BootstrapData", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.DataMapAgent", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.AgentSchedule", "AgentId", "dbo.Agent");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LogIngestion", new[] { "AgentId" });
            DropIndex("dbo.File", new[] { "Status" });
            DropIndex("dbo.File", new[] { "AgentId" });
            DropIndex("dbo.BootstrapData", new[] { "EntityId" });
            DropIndex("dbo.DataMap", new[] { "EntityId" });
            DropIndex("dbo.DataMapAgent", new[] { "AgentId" });
            DropIndex("dbo.DataMapAgent", new[] { "DataMapId" });
            DropIndex("dbo.AgentSchedule", new[] { "AgentId" });
            DropTable("dbo.NLog");
            DropTable("dbo.Statistic");
            DropTable("dbo.ProcessedData");
            DropTable("dbo.Lookup");
            DropTable("dbo.LogApplication");
            DropTable("dbo.EdFiDictionary");
            DropTable("dbo.Configuration");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LogIngestion");
            DropTable("dbo.FileStatus");
            DropTable("dbo.File");
            DropTable("dbo.BootstrapData");
            DropTable("dbo.Entity");
            DropTable("dbo.DataMap");
            DropTable("dbo.DataMapAgent");
            DropTable("dbo.AgentSchedule");
            DropTable("dbo.Agent");
        }
    }
}
