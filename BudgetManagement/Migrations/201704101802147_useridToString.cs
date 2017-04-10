namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transaction", new[] { "User_Id" });
            DropColumn("dbo.Transaction", "UserID");
            RenameColumn(table: "dbo.Transaction", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Transaction", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transaction", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transaction", new[] { "UserID" });
            AlterColumn("dbo.Transaction", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Transaction", name: "UserID", newName: "User_Id");
            AddColumn("dbo.Transaction", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "User_Id");
        }
    }
}
