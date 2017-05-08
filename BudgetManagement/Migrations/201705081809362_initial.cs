namespace BudgetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRight",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlWrite = c.Boolean(nullable: false),
                        FlAdmin = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => new { t.AccountId, t.UserID }, unique: true, name: "IX_UserAndAccount");
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        AccountTypeID = c.Int(nullable: false),
                        DueDate = c.DateTime(),
                        Limit = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        Description = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AccountTypeID)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Job = c.String(),
                        MaritalStatus = c.String(),
                        Timestamp = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        TransactionTypeId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        FlRead = c.Boolean(nullable: false),
                        FlWrite = c.Boolean(nullable: false),
                        FlAdmin = c.Boolean(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.GroupId)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        AccountID = c.Int(nullable: false),
                        TransactionTypeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(),
                        TransactionType = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AccountID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "UserID", "dbo.User");
            DropForeignKey("dbo.Transaction", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Transaction", "AccountID", "dbo.Account");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GroupUser", "UserID", "dbo.User");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Category", "UserId", "dbo.User");
            DropForeignKey("dbo.AccountRight", "UserID", "dbo.User");
            DropForeignKey("dbo.AccountRight", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Account", "UserID", "dbo.User");
            DropForeignKey("dbo.IdentityUserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogin", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Account", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Account", "AccountTypeID", "dbo.AccountType");
            DropIndex("dbo.Transaction", new[] { "CategoryID" });
            DropIndex("dbo.Transaction", new[] { "AccountID" });
            DropIndex("dbo.Transaction", new[] { "UserID" });
            DropIndex("dbo.GroupUser", new[] { "UserID" });
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            DropIndex("dbo.Category", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.Account", new[] { "CurrencyId" });
            DropIndex("dbo.Account", new[] { "AccountTypeID" });
            DropIndex("dbo.Account", new[] { "UserID" });
            DropIndex("dbo.AccountRight", "IX_UserAndAccount");
            DropTable("dbo.Transaction");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.GroupUser");
            DropTable("dbo.Group");
            DropTable("dbo.Category");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Currency");
            DropTable("dbo.AccountType");
            DropTable("dbo.Account");
            DropTable("dbo.AccountRight");
        }
    }
}
