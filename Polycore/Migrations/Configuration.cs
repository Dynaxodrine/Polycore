using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Polycore.Models;

namespace Polycore.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Polycore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Polycore.Models.ApplicationDbContext context)
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

            if (!context.Roles.Any(r => r.Name == "Administrator" 
                                        && r.Name == "Moderator" 
                                        && r.Name == "Editor" 
                                        && r.Name == "Member"))
            {
                context.Roles.AddOrUpdate(new IdentityRole() { Name = "Administrator" });
                context.Roles.AddOrUpdate(new IdentityRole() { Name = "Moderator" });
                context.Roles.AddOrUpdate(new IdentityRole() { Name = "Editor" });
                context.Roles.AddOrUpdate(new IdentityRole() { Name = "Member" });
            }

            if (!context.Users.Any(u => u.Email == "jeffreyzwirs@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "JeffreyZwirs",
                    Email = "jeffreyzwirs@gmail.com",
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Administrator");
                manager.AddToRole(user.Id, "Member");
            }
        }
    }
}
