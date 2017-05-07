namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryEntityTransType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "TransactionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "TransactionType", c => c.Int(nullable: false));
        }
    }
}
