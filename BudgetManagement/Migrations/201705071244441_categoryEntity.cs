namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Category", "TransactionTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Category", "TransactionType", c => c.Int(nullable: false));
            CreateIndex("dbo.Category", "UserId");
            AddForeignKey("dbo.Category", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "UserId", "dbo.User");
            DropIndex("dbo.Category", new[] { "UserId" });
            DropColumn("dbo.Category", "TransactionType");
            DropColumn("dbo.Category", "TransactionTypeId");
            DropColumn("dbo.Category", "UserId");
        }
    }
}
