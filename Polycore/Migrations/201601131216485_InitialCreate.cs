namespace Polycore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Commented = c.DateTime(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CommentParent_CommentID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        NewsArticleModel_NewsArticleID = c.Int(),
                        PostModel_PostID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comments", t => t.CommentParent_CommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleModel_NewsArticleID)
                .ForeignKey("dbo.Posts", t => t.PostModel_PostID)
                .Index(t => t.CommentParent_CommentID)
                .Index(t => t.User_Id)
                .Index(t => t.NewsArticleModel_NewsArticleID)
                .Index(t => t.PostModel_PostID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Age = c.Int(),
                        ProfilePicture = c.String(),
                        AboutMe = c.String(),
                        Gender = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        NewsArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Published = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NewsArticleID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        Posted = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Comment_CommentID = c.Int(),
                        Subject_SubjectID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentID)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Comment_CommentID)
                .Index(t => t.Subject_SubjectID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Game_GameID = c.Int(),
                        SubjectParent_SubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .ForeignKey("dbo.Subjects", t => t.SubjectParent_SubjectID)
                .Index(t => t.Game_GameID)
                .Index(t => t.SubjectParent_SubjectID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Console_ConsoleID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Consoles", t => t.Console_ConsoleID)
                .Index(t => t.Console_ConsoleID);
            
            CreateTable(
                "dbo.Consoles",
                c => new
                    {
                        ConsoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ConsoleID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "SubjectParent_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Posts", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "Console_ConsoleID", "dbo.Consoles");
            DropForeignKey("dbo.Comments", "PostModel_PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Comment_CommentID", "dbo.Comments");
            DropForeignKey("dbo.NewsArticles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "NewsArticleModel_NewsArticleID", "dbo.NewsArticles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "CommentParent_CommentID", "dbo.Comments");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Games", new[] { "Console_ConsoleID" });
            DropIndex("dbo.Subjects", new[] { "SubjectParent_SubjectID" });
            DropIndex("dbo.Subjects", new[] { "Game_GameID" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Posts", new[] { "Comment_CommentID" });
            DropIndex("dbo.NewsArticles", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "PostModel_PostID" });
            DropIndex("dbo.Comments", new[] { "NewsArticleModel_NewsArticleID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "CommentParent_CommentID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Consoles");
            DropTable("dbo.Games");
            DropTable("dbo.Subjects");
            DropTable("dbo.Posts");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
