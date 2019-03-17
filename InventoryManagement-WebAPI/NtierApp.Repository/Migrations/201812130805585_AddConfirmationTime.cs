namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfirmationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ConfirmationTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ConfirmationTime");
        }
    }
}
