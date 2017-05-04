namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountRight", "FlAdmin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AccountRight", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AccountRight", "UserID");
            AddForeignKey("dbo.AccountRight", "UserID", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountRight", "UserID", "dbo.User");
            DropIndex("dbo.AccountRight", new[] { "UserID" });
            AlterColumn("dbo.AccountRight", "UserID", c => c.String());
            DropColumn("dbo.AccountRight", "FlAdmin");
        }
    }
}
