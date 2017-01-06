namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventusers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserEvents", newName: "EventUsers");
            RenameColumn(table: "dbo.EventUsers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.EventUsers", name: "Event_Id", newName: "EventId");
            RenameIndex(table: "dbo.EventUsers", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.EventUsers", name: "IX_Event_Id", newName: "IX_EventId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EventUsers", name: "IX_EventId", newName: "IX_Event_Id");
            RenameIndex(table: "dbo.EventUsers", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.EventUsers", name: "EventId", newName: "Event_Id");
            RenameColumn(table: "dbo.EventUsers", name: "UserId", newName: "User_Id");
            RenameTable(name: "dbo.EventUsers", newName: "UserEvents");
        }
    }
}
