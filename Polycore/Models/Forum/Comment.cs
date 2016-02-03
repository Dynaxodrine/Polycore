using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polycore.Models.Forum
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime? Commented { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
        public virtual NewsArticle NewsArticle { get; set; }
        public virtual Comment CommentParent { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}