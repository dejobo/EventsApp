namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionevent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sessions", "EventId");
            AddForeignKey("dbo.Sessions", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "EventId", "dbo.Events");
            DropIndex("dbo.Sessions", new[] { "EventId" });
            DropColumn("dbo.Sessions", "EventId");
        }
    }
}
