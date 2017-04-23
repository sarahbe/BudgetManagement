namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.AccountType", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currency", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Category", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.TransactionType", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionType", "Timestamp");
            DropColumn("dbo.Transaction", "Timestamp");
            DropColumn("dbo.Category", "Timestamp");
            DropColumn("dbo.Currency", "Timestamp");
            DropColumn("dbo.AccountType", "Timestamp");
            DropColumn("dbo.Account", "Timestamp");
        }
    }
}
