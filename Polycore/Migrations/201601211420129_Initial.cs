namespace Polycore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Art",
                c => new
                    {
                        ArtID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        OriginalUrl = c.String(),
                        Type = c.Int(nullable: false),
                        Game_GameID = c.Int(),
                        Game_GameID1 = c.Int(),
                        Game_GameID2 = c.Int(),
                        Game_GameID3 = c.Int(),
                        Game_GameID4 = c.Int(),
                    })
                .PrimaryKey(t => t.ArtID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .ForeignKey("dbo.Games", t => t.Game_GameID1)
                .ForeignKey("dbo.Games", t => t.Game_GameID2)
                .ForeignKey("dbo.Games", t => t.Game_GameID3)
                .ForeignKey("dbo.Games", t => t.Game_GameID4)
                .Index(t => t.Game_GameID)
                .Index(t => t.Game_GameID1)
                .Index(t => t.Game_GameID2)
                .Index(t => t.Game_GameID3)
                .Index(t => t.Game_GameID4);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        YoutubeUrl = c.String(),
                        Rating = c.Single(nullable: false),
                        CoOp_CoOpID = c.Int(),
                        Developer_DeveloperID = c.Int(),
                        Publisher_PublisherID = c.Int(),
                        Esrb_EsrbID = c.Int(),
                        Logo_ArtID = c.Int(),
                        Players_PlayersID = c.Int(),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.CoOps", t => t.CoOp_CoOpID)
                .ForeignKey("dbo.Developers", t => t.Developer_DeveloperID)
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherID)
                .ForeignKey("dbo.Esrbs", t => t.Esrb_EsrbID)
                .ForeignKey("dbo.Art", t => t.Logo_ArtID)
                .ForeignKey("dbo.Players", t => t.Players_PlayersID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .Index(t => t.CoOp_CoOpID)
                .Index(t => t.Developer_DeveloperID)
                .Index(t => t.Publisher_PublisherID)
                .Index(t => t.Esrb_EsrbID)
                .Index(t => t.Logo_ArtID)
                .Index(t => t.Players_PlayersID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.CoOps",
                c => new
                    {
                        CoOpID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CoOpID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Platform_PlatformId = c.Int(),
                    })
                .PrimaryKey(t => t.GenreID)
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformId)
                .Index(t => t.Platform_PlatformId);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        PlatformId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlatformId);
            
            CreateTable(
                "dbo.Esrbs",
                c => new
                    {
                        EsrbID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EsrbID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayersID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlayersID);
            
            CreateTable(
                "dbo.GameSubject",
                c => new
                    {
                        GameSubjectID = c.Int(nullable: false, identity: true),
                        Details_GameID = c.Int(),
                        Platform_PlatformId = c.Int(),
                    })
                .PrimaryKey(t => t.GameSubjectID)
                .ForeignKey("dbo.Games", t => t.Details_GameID)
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformId)
                .Index(t => t.Details_GameID)
                .Index(t => t.Platform_PlatformId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Game_GameID = c.Int(),
                        SubjectParent_SubjectID = c.Int(),
                        GameSubject_GameSubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .ForeignKey("dbo.Subjects", t => t.SubjectParent_SubjectID)
                .ForeignKey("dbo.GameSubject", t => t.GameSubject_GameSubjectID)
                .Index(t => t.Game_GameID)
                .Index(t => t.SubjectParent_SubjectID)
                .Index(t => t.GameSubject_GameSubjectID);
            
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
                        User_Id = c.String(maxLength: 128),
                        Subject_SubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID)
                .Index(t => t.User_Id)
                .Index(t => t.Subject_SubjectID);
            
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
                        NewsArticle_NewsArticleID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        Post_PostID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comments", t => t.CommentParent_CommentID)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticle_NewsArticleID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Posts", t => t.Post_PostID)
                .Index(t => t.CommentParent_CommentID)
                .Index(t => t.NewsArticle_NewsArticleID)
                .Index(t => t.User_Id)
                .Index(t => t.Post_PostID);
            
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
            
            CreateTable(
                "dbo.SteamGames",
                c => new
                    {
                        SteamGameID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AppId = c.Int(nullable: false),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.SteamGameID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.TwitchArt",
                c => new
                    {
                        TwitchArtID = c.Int(nullable: false, identity: true),
                        Large_ArtID = c.Int(),
                        Medium_ArtID = c.Int(),
                        Small_ArtID = c.Int(),
                    })
                .PrimaryKey(t => t.TwitchArtID)
                .ForeignKey("dbo.Art", t => t.Large_ArtID)
                .ForeignKey("dbo.Art", t => t.Medium_ArtID)
                .ForeignKey("dbo.Art", t => t.Small_ArtID)
                .Index(t => t.Large_ArtID)
                .Index(t => t.Medium_ArtID)
                .Index(t => t.Small_ArtID);
            
            CreateTable(
                "dbo.TwitchGames",
                c => new
                    {
                        TwitchGameID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TwitchId = c.Int(nullable: false),
                        GiantBomb = c.Int(nullable: false),
                        Boxart_TwitchArtID = c.Int(),
                        Logo_TwitchArtID = c.Int(),
                    })
                .PrimaryKey(t => t.TwitchGameID)
                .ForeignKey("dbo.TwitchArt", t => t.Boxart_TwitchArtID)
                .ForeignKey("dbo.TwitchArt", t => t.Logo_TwitchArtID)
                .Index(t => t.Boxart_TwitchArtID)
                .Index(t => t.Logo_TwitchArtID);
            
            CreateTable(
                "dbo.GenreDevelopers",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Developer_DeveloperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Developer_DeveloperID })
                .ForeignKey("dbo.Genre", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_DeveloperID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Developer_DeveloperID);
            
            CreateTable(
                "dbo.GenreGames",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Game_GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Game_GameID })
                .ForeignKey("dbo.Genre", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_GameID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.PublisherDevelopers",
                c => new
                    {
                        Publisher_PublisherID = c.Int(nullable: false),
                        Developer_DeveloperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherID, t.Developer_DeveloperID })
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_DeveloperID, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherID)
                .Index(t => t.Developer_DeveloperID);
            
            CreateTable(
                "dbo.PublisherGenres",
                c => new
                    {
                        Publisher_PublisherID = c.Int(nullable: false),
                        Genre_GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherID, t.Genre_GenreID })
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.Genre_GenreID, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherID)
                .Index(t => t.Genre_GenreID);
            
            CreateTable(
                "dbo.PlatformDevelopers",
                c => new
                    {
                        Platform_PlatformId = c.Int(nullable: false),
                        Developer_DeveloperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_PlatformId, t.Developer_DeveloperID })
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformId, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_DeveloperID, cascadeDelete: true)
                .Index(t => t.Platform_PlatformId)
                .Index(t => t.Developer_DeveloperID);
            
            CreateTable(
                "dbo.PlatformGames",
                c => new
                    {
                        Platform_PlatformId = c.Int(nullable: false),
                        Game_GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_PlatformId, t.Game_GameID })
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_GameID, cascadeDelete: true)
                .Index(t => t.Platform_PlatformId)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.PlatformPublishers",
                c => new
                    {
                        Platform_PlatformId = c.Int(nullable: false),
                        Publisher_PublisherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_PlatformId, t.Publisher_PublisherID })
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherID, cascadeDelete: true)
                .Index(t => t.Platform_PlatformId)
                .Index(t => t.Publisher_PublisherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TwitchGames", "Logo_TwitchArtID", "dbo.TwitchArt");
            DropForeignKey("dbo.TwitchGames", "Boxart_TwitchArtID", "dbo.TwitchArt");
            DropForeignKey("dbo.TwitchArt", "Small_ArtID", "dbo.Art");
            DropForeignKey("dbo.TwitchArt", "Medium_ArtID", "dbo.Art");
            DropForeignKey("dbo.TwitchArt", "Large_ArtID", "dbo.Art");
            DropForeignKey("dbo.SteamGames", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Art", "Game_GameID4", "dbo.Games");
            DropForeignKey("dbo.Subjects", "GameSubject_GameSubjectID", "dbo.GameSubject");
            DropForeignKey("dbo.Subjects", "SubjectParent_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Posts", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewsArticles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "NewsArticle_NewsArticleID", "dbo.NewsArticles");
            DropForeignKey("dbo.Comments", "CommentParent_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Subjects", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.GameSubject", "Platform_PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.GameSubject", "Details_GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Art", "Game_GameID3", "dbo.Games");
            DropForeignKey("dbo.Games", "Players_PlayersID", "dbo.Players");
            DropForeignKey("dbo.Games", "Logo_ArtID", "dbo.Art");
            DropForeignKey("dbo.Art", "Game_GameID2", "dbo.Games");
            DropForeignKey("dbo.Games", "Esrb_EsrbID", "dbo.Esrbs");
            DropForeignKey("dbo.PlatformPublishers", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.PlatformPublishers", "Platform_PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.Genre", "Platform_PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.PlatformGames", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.PlatformGames", "Platform_PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.PlatformDevelopers", "Developer_DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.PlatformDevelopers", "Platform_PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.PublisherGenres", "Genre_GenreID", "dbo.Genre");
            DropForeignKey("dbo.PublisherGenres", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Games", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.PublisherDevelopers", "Developer_DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.PublisherDevelopers", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.GenreGames", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.GenreGames", "Genre_GenreID", "dbo.Genre");
            DropForeignKey("dbo.GenreDevelopers", "Developer_DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.GenreDevelopers", "Genre_GenreID", "dbo.Genre");
            DropForeignKey("dbo.Games", "Developer_DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.Games", "CoOp_CoOpID", "dbo.CoOps");
            DropForeignKey("dbo.Art", "Game_GameID1", "dbo.Games");
            DropForeignKey("dbo.Art", "Game_GameID", "dbo.Games");
            DropIndex("dbo.PlatformPublishers", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.PlatformPublishers", new[] { "Platform_PlatformId" });
            DropIndex("dbo.PlatformGames", new[] { "Game_GameID" });
            DropIndex("dbo.PlatformGames", new[] { "Platform_PlatformId" });
            DropIndex("dbo.PlatformDevelopers", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.PlatformDevelopers", new[] { "Platform_PlatformId" });
            DropIndex("dbo.PublisherGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.PublisherGenres", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.PublisherDevelopers", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.PublisherDevelopers", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.GenreGames", new[] { "Game_GameID" });
            DropIndex("dbo.GenreGames", new[] { "Genre_GenreID" });
            DropIndex("dbo.GenreDevelopers", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.GenreDevelopers", new[] { "Genre_GenreID" });
            DropIndex("dbo.TwitchGames", new[] { "Logo_TwitchArtID" });
            DropIndex("dbo.TwitchGames", new[] { "Boxart_TwitchArtID" });
            DropIndex("dbo.TwitchArt", new[] { "Small_ArtID" });
            DropIndex("dbo.TwitchArt", new[] { "Medium_ArtID" });
            DropIndex("dbo.TwitchArt", new[] { "Large_ArtID" });
            DropIndex("dbo.SteamGames", new[] { "Game_GameID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.NewsArticles", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "NewsArticle_NewsArticleID" });
            DropIndex("dbo.Comments", new[] { "CommentParent_CommentID" });
            DropIndex("dbo.Posts", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Subjects", new[] { "GameSubject_GameSubjectID" });
            DropIndex("dbo.Subjects", new[] { "SubjectParent_SubjectID" });
            DropIndex("dbo.Subjects", new[] { "Game_GameID" });
            DropIndex("dbo.GameSubject", new[] { "Platform_PlatformId" });
            DropIndex("dbo.GameSubject", new[] { "Details_GameID" });
            DropIndex("dbo.Genre", new[] { "Platform_PlatformId" });
            DropIndex("dbo.Games", new[] { "Game_GameID" });
            DropIndex("dbo.Games", new[] { "Players_PlayersID" });
            DropIndex("dbo.Games", new[] { "Logo_ArtID" });
            DropIndex("dbo.Games", new[] { "Esrb_EsrbID" });
            DropIndex("dbo.Games", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.Games", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.Games", new[] { "CoOp_CoOpID" });
            DropIndex("dbo.Art", new[] { "Game_GameID4" });
            DropIndex("dbo.Art", new[] { "Game_GameID3" });
            DropIndex("dbo.Art", new[] { "Game_GameID2" });
            DropIndex("dbo.Art", new[] { "Game_GameID1" });
            DropIndex("dbo.Art", new[] { "Game_GameID" });
            DropTable("dbo.PlatformPublishers");
            DropTable("dbo.PlatformGames");
            DropTable("dbo.PlatformDevelopers");
            DropTable("dbo.PublisherGenres");
            DropTable("dbo.PublisherDevelopers");
            DropTable("dbo.GenreGames");
            DropTable("dbo.GenreDevelopers");
            DropTable("dbo.TwitchGames");
            DropTable("dbo.TwitchArt");
            DropTable("dbo.SteamGames");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Subjects");
            DropTable("dbo.GameSubject");
            DropTable("dbo.Players");
            DropTable("dbo.Esrbs");
            DropTable("dbo.Platforms");
            DropTable("dbo.Publisher");
            DropTable("dbo.Genre");
            DropTable("dbo.Developers");
            DropTable("dbo.CoOps");
            DropTable("dbo.Games");
            DropTable("dbo.Art");
        }
    }
}
