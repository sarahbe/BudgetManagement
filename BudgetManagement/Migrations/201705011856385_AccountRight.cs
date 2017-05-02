namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountRight : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRight",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        FlWrite = c.Boolean(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountRight");
        }
    }
}
