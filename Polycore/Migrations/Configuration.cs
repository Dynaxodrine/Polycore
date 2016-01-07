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
            var jeffrey = new ApplicationUser
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
            manager.AddToRole(hugo.Id, "Member");

            context.Categories.AddOrUpdate(p => p.Game,
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 1 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 2 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 3 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 4 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 5 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 6 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 7 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 8 },
                 new CategoryModels { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 9 },

                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 1 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 2 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 3 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 4 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 5 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 6 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 7 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 8 },
                 new CategoryModels { Console = "XBOX", Game = "Halo 5", SubjectId = 9 });

            context.Subjects.AddOrUpdate(p => p.Title,
                 new SubjectModels { Title = "Let's plays" },
                 new SubjectModels { Title = "Guides" },
                 new SubjectModels { Title = "Cheats" },
                 new SubjectModels { Title = "General discussion" },
                 new SubjectModels { Title = "Help" },
                 new SubjectModels { Title = "Mods" },
                 new SubjectModels { Title = "Request" },
                 new SubjectModels { Title = "Review" },
                 new SubjectModels { Title = "Development" });
        }
    }
}