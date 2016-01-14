namespace Polycore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "NewsArticleModel_NewsArticleID", newName: "NewsArticle_NewsArticleID");
            RenameIndex(table: "dbo.Comments", name: "IX_NewsArticleModel_NewsArticleID", newName: "IX_NewsArticle_NewsArticleID");
            AddColumn("dbo.Comments", "Post_PostID", c => c.Int());
            CreateIndex("dbo.Comments", "Post_PostID");
            AddForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts", "PostID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            DropColumn("dbo.Comments", "Post_PostID");
            RenameIndex(table: "dbo.Comments", name: "IX_NewsArticle_NewsArticleID", newName: "IX_NewsArticleModel_NewsArticleID");
            RenameColumn(table: "dbo.Comments", name: "NewsArticle_NewsArticleID", newName: "NewsArticleModel_NewsArticleID");
        }
    }
}
