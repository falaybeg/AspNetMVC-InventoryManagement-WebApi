namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Description", c => c.String());
            DropColumn("dbo.Purchases", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Message", c => c.String());
            DropColumn("dbo.Purchases", "Description");
        }
    }
}
