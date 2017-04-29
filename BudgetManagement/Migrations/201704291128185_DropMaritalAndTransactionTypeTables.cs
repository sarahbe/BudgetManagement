namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMaritalAndTransactionTypeTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "TransactionTypeID", "dbo.TransactionType");
            DropIndex("dbo.Transaction", new[] { "TransactionTypeID" });
            AddColumn("dbo.Transaction", "TransactionType", c => c.Int(nullable: false));
            DropTable("dbo.TransactionType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransactionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Desctiption = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Transaction", "TransactionType");
            CreateIndex("dbo.Transaction", "TransactionTypeID");
            AddForeignKey("dbo.Transaction", "TransactionTypeID", "dbo.TransactionType", "ID", cascadeDelete: true);
        }
    }
}
