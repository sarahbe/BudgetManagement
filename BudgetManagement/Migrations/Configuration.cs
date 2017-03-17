namespace BudgetManagement.Migrations
{
    using BudgetManagement.DAL;
    using BudgetManagement.Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BudgetManagement.DAL.BudgetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudgetManagement.DAL.BudgetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var manager = new UserManager<User>(new UserStore<User>(new BudgetContext()));

            //var user = new User()
            //{
            //    UserName = "SuperPowerUser",
            //    Email = "taiseer.joudeh@mymail.com",
            //    EmailConfirmed = true
            //};

            //manager.Create(user, "MySuperP@ssword!");

             var manager = new UserManager<User>(new UserStore<User>(new BudgetContext()));

            var user = new User()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@mymail.com",
               // EmailConfirmed = true,
                FullName = "Sarah Beirkdar",
                MaritalStatus = "Single",
                Job="Engineer",
                Birthdate = new DateTime(1990,1,1)
            };

            manager.Create(user, "MySuperP@ssword!");
        }
    }
}
