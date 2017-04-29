namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Description", c => c.String());
            AddColumn("dbo.Account", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Balance");
            DropColumn("dbo.Account", "Description");
        }
    }
}
