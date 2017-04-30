namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timestampToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Timestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Timestamp");
        }
    }
}
