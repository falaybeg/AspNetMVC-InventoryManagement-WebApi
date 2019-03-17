namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPurchaseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "DeliveryTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Message");
            DropColumn("dbo.Purchases", "DeliveryTime");
        }
    }
}
