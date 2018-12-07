namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "DeliveryTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "DeliveryTime", c => c.DateTime(nullable: false));
        }
    }
}
