namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "Job", c => c.String());
            AddColumn("dbo.User", "MaritalStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "MaritalStatus");
            DropColumn("dbo.User", "Job");
            DropColumn("dbo.User", "Birthdate");
        }
    }
}
