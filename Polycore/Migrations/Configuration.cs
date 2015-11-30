using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Polycore.Models;

namespace Polycore.Migrations
{
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
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Administrator", Id = "admin" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Moderator", Id = "mod" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Editor", Id = "editor" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Member", Id = "member" });
        }
    }
}
