namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserID = c.String(),
                        FlRead = c.Boolean(nullable: false),
                        FlWrite = c.Boolean(nullable: false),
                        FlAdmin = c.Boolean(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupUser");
            DropTable("dbo.Group");
        }
    }
}
