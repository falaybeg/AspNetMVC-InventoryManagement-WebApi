namespace NtierApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DenemeMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "UserRole_Id" });
            DropColumn("dbo.AspNetUsers", "UserRole_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "UserRole_Id");
            AddForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles", "Id");
        }
    }
}
