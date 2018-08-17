namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderShippinAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingAdress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingAdress");
        }
    }
}
