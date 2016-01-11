
namespace Polycore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Evurryting : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Articles");
            DropTable("dbo.Categories");
            DropTable("dbo.ForumPosts");
            DropTable("dbo.Subjects");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Commented = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CommentParent_CommentID = c.Int(),
                        Post_PostID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        NewsArticleModel_NewsArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comments", t => t.CommentParent_CommentID)
                .ForeignKey("dbo.Posts", t => t.Post_PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleModel_NewsArticleID)
                .Index(t => t.CommentParent_CommentID)
                .Index(t => t.Post_PostID)
                .Index(t => t.User_Id)
                .Index(t => t.NewsArticleModel_NewsArticleID);
            
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
                        Subject_SubjectID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
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
            
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
            AddColumn("dbo.AspNetUsers", "AboutMe", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.ForumPosts",
                c => new
                    {
                        ForumPostId = c.Single(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Posted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ForumPostId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Console = c.String(nullable: false),
                        Game = c.String(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewsArticles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "NewsArticleModel_NewsArticleID", "dbo.NewsArticles");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "SubjectParent_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Posts", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "Console_ConsoleID", "dbo.Consoles");
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "CommentParent_CommentID", "dbo.Comments");
            DropIndex("dbo.NewsArticles", new[] { "User_Id" });
            DropIndex("dbo.Games", new[] { "Console_ConsoleID" });
            DropIndex("dbo.Subjects", new[] { "SubjectParent_SubjectID" });
            DropIndex("dbo.Subjects", new[] { "Game_GameID" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Comments", new[] { "NewsArticleModel_NewsArticleID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            DropIndex("dbo.Comments", new[] { "CommentParent_CommentID" });
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "AboutMe");
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.Consoles");
            DropTable("dbo.Games");
            DropTable("dbo.Subjects");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
