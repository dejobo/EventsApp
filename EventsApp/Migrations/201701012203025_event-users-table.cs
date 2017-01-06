namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventuserstable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventUsers", newName: "UserEvents");
            RenameColumn(table: "dbo.UserEvents", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserEvents", name: "EventId", newName: "Event_Id");
            RenameIndex(table: "dbo.UserEvents", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.UserEvents", name: "IX_EventId", newName: "IX_Event_Id");
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.EventUsers", "EventId", "dbo.Events");
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            DropTable("dbo.EventUsers");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Event_Id", newName: "IX_EventId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserEvents", name: "Event_Id", newName: "EventId");
            RenameColumn(table: "dbo.UserEvents", name: "User_Id", newName: "UserId");
            RenameTable(name: "dbo.UserEvents", newName: "EventUsers");
        }
    }
}
