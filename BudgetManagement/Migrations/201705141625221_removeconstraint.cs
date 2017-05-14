namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeconstraint : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountRight", "IX_UserAndAccount");
            CreateIndex("dbo.AccountRight", "AccountId");
            CreateIndex("dbo.AccountRight", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountRight", new[] { "UserID" });
            DropIndex("dbo.AccountRight", new[] { "AccountId" });
            CreateIndex("dbo.AccountRight", new[] { "AccountId", "UserID" }, unique: true, name: "IX_UserAndAccount");
        }
    }
}
