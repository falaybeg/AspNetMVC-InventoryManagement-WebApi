namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "UserRole_Id");
            AddForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "UserRole_Id" });
            DropColumn("dbo.AspNetUsers", "UserRole_Id");
        }
    }
}
