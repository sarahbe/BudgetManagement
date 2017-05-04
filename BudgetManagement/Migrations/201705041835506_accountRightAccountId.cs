namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountRightAccountId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountRight", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountRight", "AccountId");
            AddForeignKey("dbo.AccountRight", "AccountId", "dbo.Account", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountRight", "AccountId", "dbo.Account");
            DropIndex("dbo.AccountRight", new[] { "AccountId" });
            DropColumn("dbo.AccountRight", "AccountId");
        }
    }
}
