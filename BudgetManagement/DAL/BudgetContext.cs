using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BudgetManagement.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using BudgetManagement.Domain;

namespace BudgetManagement.DAL
{
    public class BudgetContext : IdentityDbContext<User>

    {
        //This is the name of connection string
     public BudgetContext() : base("BudgetContext")
        {

        }
        //The static method “Create” will be called from our Owin Startup class.
        public static BudgetContext Create()
        {
            return new BudgetContext();
        }

        public DbSet<Account> Accounts { get; set; }
        //public DbSet<Right> Rights { get; set; }
        public DbSet<Category> Categories { get; set; }  
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        //preventint table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

    }
}