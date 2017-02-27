using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BudgetManagement.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BudgetManagement.DAL
{
    public class BudgetContext : DbContext

    {
        //This is the name of connection string
     public BudgetContext() : base("BudgetContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //preventint table names from bein pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}