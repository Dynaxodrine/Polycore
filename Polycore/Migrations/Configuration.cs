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
                EmailConfirmed = true
            };
            var user2 = new ApplicationUser
            {
                UserName = "Hugo",
                Email = "hugo@gmail.com",
                EmailConfirmed = true
            };

            manager.Create(user1, "123456");
            manager.AddToRole(user1.Id, "Administrator");
            manager.AddToRole(user1.Id, "Member");

            manager.Create(user2, "123456");
            manager.AddToRole(user2.Id, "Member");

            context.Categories.AddOrUpdate(p => p.Game,
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 1 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 2 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 3 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 4 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 5 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 6 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 7 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 8 },
                 new Categories { Console = "PC", Game = "Starcraft 2 legacy of the void", SubjectId = 9 },

                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 1 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 2 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 3 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 4 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 5 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 6 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 7 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 8 },
                 new Categories { Console = "XBOX", Game = "Halo 5", SubjectId = 9 });

            context.Subjects.AddOrUpdate(p => p.Title,
                 new Subjects { Title = "Let's plays" },
                 new Subjects { Title = "Guides" },
                 new Subjects { Title = "Cheats" },
                 new Subjects { Title = "General discussion" },
                 new Subjects { Title = "Help" },
                 new Subjects { Title = "Mods" },
                 new Subjects { Title = "Request" },
                 new Subjects { Title = "Review" },
                 new Subjects { Title = "Development" });
        }
    }
}
