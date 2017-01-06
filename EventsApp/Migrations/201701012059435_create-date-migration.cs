namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatemigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Updated");
            DropColumn("dbo.Users", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Updated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "Created");
            DropColumn("dbo.Events", "Created");
        }
    }
}
