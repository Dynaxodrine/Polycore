using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Polycore.Models;

namespace Polycore.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
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
            /*var jeffrey = new ApplicationUser
            {
                UserName = "JeffreyZwirs",
                Email = "jeffreyzwirs@gmail.com",
                EmailConfirmed = true
            };
            var hugo = new ApplicationUser
            {
                UserName = "Administrator",
                Email = "administrator@polycore.com",
                EmailConfirmed = true
            };

            manager.Create(jeffrey, "123456");
            manager.AddToRole(jeffrey.Id, "Administrator");
            manager.AddToRole(jeffrey.Id, "Member");

            manager.Create(hugo, "123456");
            manager.AddToRole(hugo.Id, "Administrator");
            manager.AddToRole(hugo.Id, "Member");*/

            

            //var games = new List<GameModel>{
            //    new GameModel { Name = "Starcraft 2 legacy of the void" },
            //    new GameModel { Name = "Halo 5" },
            //    new GameModel { Name = "Mass effect Adromeda" }
            //};

            //games.ForEach(c => context.Games.AddOrUpdate(m => m.Name, c));
            //context.SaveChanges();

            //var subjects = new List<SubjectModel>{
            //    new SubjectModel { Name = "test1" },
            //    new SubjectModel { Name = "test2" },
            //    new SubjectModel { Name = "test3" }
            //};

            //subjects.ForEach(c => context.Subjects.AddOrUpdate(m => m.Name, c));
            //context.SaveChanges();
        }
    }
}