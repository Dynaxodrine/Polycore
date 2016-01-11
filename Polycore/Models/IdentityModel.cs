using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Polycore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Range(0, 122)]
        public int? Age { get; set; }
        public string ProfilePicture { get; set; }
        public string AboutMe { get; set; }
        public Types.Gender Gender { get; set; }

        public virtual List<PostModel> Posts { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
        public virtual List<NewsArticleModel> NewsArticles { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ConsoleModel> Consoles { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<NewsArticleModel> NewsArticles { get; set; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}