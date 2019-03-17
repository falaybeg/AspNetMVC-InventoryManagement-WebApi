namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingAddress");
        }
    }
}
