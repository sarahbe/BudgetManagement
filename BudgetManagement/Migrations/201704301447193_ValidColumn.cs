namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.AccountType", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Currency", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Category", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Group", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupUser", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaction", "Valid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "Valid");
            DropColumn("dbo.GroupUser", "Valid");
            DropColumn("dbo.Group", "Valid");
            DropColumn("dbo.Category", "Valid");
            DropColumn("dbo.Currency", "Valid");
            DropColumn("dbo.AccountType", "Valid");
            DropColumn("dbo.Account", "Valid");
        }
    }
}
