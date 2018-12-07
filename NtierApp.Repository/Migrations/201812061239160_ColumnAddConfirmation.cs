namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Confirmation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Confirmation");
        }
    }
}
