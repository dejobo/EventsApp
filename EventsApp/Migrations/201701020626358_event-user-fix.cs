namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventuserfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventUsers", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventUsers", "UserId", "dbo.Users");
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            DropTable("dbo.EventUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.EventUsers", "UserId");
            CreateIndex("dbo.EventUsers", "EventId");
            AddForeignKey("dbo.EventUsers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventUsers", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
