namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTableColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegisteredDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "RegisteredData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RegisteredData", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            DropColumn("dbo.AspNetUsers", "RegisteredDate");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
