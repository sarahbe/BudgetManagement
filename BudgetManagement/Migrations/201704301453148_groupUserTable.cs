namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupUser", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.GroupUser", "GroupId");
            CreateIndex("dbo.GroupUser", "UserID");
            AddForeignKey("dbo.GroupUser", "GroupId", "dbo.Group", "ID", cascadeDelete: true);
            AddForeignKey("dbo.GroupUser", "UserID", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUser", "UserID", "dbo.User");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.Group");
            DropIndex("dbo.GroupUser", new[] { "UserID" });
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            AlterColumn("dbo.GroupUser", "UserID", c => c.String());
        }
    }
}
