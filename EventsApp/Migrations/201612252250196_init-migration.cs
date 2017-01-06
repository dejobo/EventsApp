namespace EventsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Updated");
            DropColumn("dbo.Events", "Updated");
        }
    }
}
