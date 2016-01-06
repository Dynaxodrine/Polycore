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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Console is required.")]
        public string Console { get; set; }
        [Required(ErrorMessage = "Game is required.")]
        public string Game { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public int SubjectId { get; set; }
    }

    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }

    public class Articles
    {
        [Key]
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }        
        public string Content { get; set; }
    }
    
    public class Messages
    {
        [Key]
        public float MessageId { get; set; }
        public string UserId { get; set; }
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Message is required.")]           
        public string Message { get; set; } 
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Messages> Messages { get; set; }
                
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}