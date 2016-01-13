namespace Polycore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Post_PostID", newName: "PostModel_PostID");
            RenameIndex(table: "dbo.Comments", name: "IX_Post_PostID", newName: "IX_PostModel_PostID");
            AddColumn("dbo.Posts", "Comment_CommentID", c => c.Int());
            AlterColumn("dbo.Comments", "Commented", c => c.DateTime());
            CreateIndex("dbo.Posts", "Comment_CommentID");
            AddForeignKey("dbo.Posts", "Comment_CommentID", "dbo.Comments", "CommentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Comment_CommentID", "dbo.Comments");
            DropIndex("dbo.Posts", new[] { "Comment_CommentID" });
            AlterColumn("dbo.Comments", "Commented", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "Comment_CommentID");
            RenameIndex(table: "dbo.Comments", name: "IX_PostModel_PostID", newName: "IX_Post_PostID");
            RenameColumn(table: "dbo.Comments", name: "PostModel_PostID", newName: "Post_PostID");
        }
    }
}
