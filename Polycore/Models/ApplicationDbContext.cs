using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Polycore.Models.Forum;
using Polycore.Models.Games;
using Polycore.Models.Games.Steam;
using Polycore.Models.Games.Twitch;

namespace Polycore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        /*
        * Forum
        */
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GameSubject> GameSubjects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }

        /*
        * Game
        */
        public DbSet<Games.Game> Games { get; set; }
        public DbSet<Art> Art { get; set; }
        public DbSet<CoOp> CoOps { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Esrb> Esrbs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        /*
        * Steam
        */
        public DbSet<SteamGame> SteamGame { get; set; }

        /*
        * Twitch
        */
        public DbSet<TwitchArt> TwitchArt { get; set; }
        public DbSet<TwitchGame> TwitchGame { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}