namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Account", "AccountTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Account", "DueDate", c => c.DateTime());
            AddColumn("dbo.Account", "Limit", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Account", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "Name", c => c.String());
            AddColumn("dbo.Transaction", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "TransactionDate", c => c.DateTime());
            CreateIndex("dbo.Account", "AccountTypeID");
            CreateIndex("dbo.Account", "CurrencyId");
            AddForeignKey("dbo.Account", "AccountTypeID", "dbo.AccountType", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Account", "CurrencyId", "dbo.Currency", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Account", "AccountTypeID", "dbo.AccountType");
            DropIndex("dbo.Account", new[] { "CurrencyId" });
            DropIndex("dbo.Account", new[] { "AccountTypeID" });
            DropColumn("dbo.Transaction", "TransactionDate");
            DropColumn("dbo.Transaction", "Amount");
            DropColumn("dbo.Transaction", "Name");
            DropColumn("dbo.Account", "CurrencyId");
            DropColumn("dbo.Account", "Limit");
            DropColumn("dbo.Account", "DueDate");
            DropColumn("dbo.Account", "AccountTypeID");
            DropTable("dbo.Currency");
            DropTable("dbo.AccountType");
        }
    }
}
