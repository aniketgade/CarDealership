namespace CarDealership.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            // Add missing roles
            var role = roleManager.FindByName("Admin");
            if (role == null)
            {
                role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            var roleSales = roleManager.FindByName("Sales");
            if (roleSales == null)
            {
                role = new IdentityRole("Sales");
                roleManager.Create(role);
            }


            var roleDisabled = roleManager.FindByName("Disabled");
            if (roleDisabled == null)
            {
                role = new IdentityRole("Disabled");
                roleManager.Create(role);
            }

            // Create test users
            var user = userManager.FindByName("admin");
            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "admin@xxx.net",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@xxx.net",
                    PhoneNumber = "5551234567",
                };
                userManager.Create(newUser, "Password1");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "Admin");
            }

            var userSales = userManager.FindByName("salesUser1");
            if (userSales == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "Sales1@xxx.net",
                    FirstName = "Sales",
                    LastName = "User1",
                    Email = "Sales1@xxx.net",
                    PhoneNumber = "7523234567",
                };
                userManager.Create(newUser, "Password1");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "Sales");
            }


            var userSales2 = userManager.FindByName("salesUser2");
            if (userSales2 == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "Sales2@xxx.net",
                    FirstName = "Sales",
                    LastName = "User2",
                    Email = "Sales2@xxx.net",
                    PhoneNumber = "9523234567",
                };
                userManager.Create(newUser, "Password1");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "Sales");
            }

            var userSales3 = userManager.FindByName("salesUser3");
            if (userSales3 == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "Sales3@xxx.net",
                    FirstName = "Sales",
                    LastName = "User3",
                    Email = "Sales3@xxx.net",
                    PhoneNumber = "3523234567",
                };
                userManager.Create(newUser, "Password1");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "Sales");
            }

            var userSales4 = userManager.FindByName("salesUser4");
            if (userSales4 == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "Sales4@xxx.net",
                    FirstName = "Sales",
                    LastName = "User4",
                    Email = "Sales4@xxx.net",
                    PhoneNumber = "8523234567",
                };
                userManager.Create(newUser, "Password1");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "Sales");
            }
        }
    }
}
