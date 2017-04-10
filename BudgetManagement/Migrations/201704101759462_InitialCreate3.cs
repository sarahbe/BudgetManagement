namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Account", new[] { "User_Id" });
            DropColumn("dbo.Account", "UserID");
            RenameColumn(table: "dbo.Account", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Account", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Currency", "Name", c => c.String());
            CreateIndex("dbo.Account", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Account", new[] { "UserID" });
            AlterColumn("dbo.Currency", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Account", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Account", name: "UserID", newName: "User_Id");
            AddColumn("dbo.Account", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Account", "User_Id");
        }
    }
}
