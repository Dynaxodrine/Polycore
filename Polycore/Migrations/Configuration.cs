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

            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Administrator" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Moderator" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Editor" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Member" });

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user1 = new ApplicationUser
            {
                UserName = "JeffreyZwirs",
                Email = "jeffreyzwirs@gmail.com",
            };
            var user2 = new ApplicationUser
            {
                UserName = "testtest",
                Email = "test@gmail.com",
            };
                
            manager.Create(user1, "123456");
            manager.AddToRole(user1.Id, "Administrator");
            manager.AddToRole(user1.Id, "Member");

            manager.Create(user2, "123456");
            manager.AddToRole(user2.Id, "Member");            
        }
    }
}
