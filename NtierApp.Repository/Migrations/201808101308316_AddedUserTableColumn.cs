namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserTableColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable:true));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: true));
            AddColumn("dbo.AspNetUsers", "RegisteredData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CardNumber", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CardNumber", c => c.String(nullable: true));
            DropColumn("dbo.AspNetUsers", "RegisteredData");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
