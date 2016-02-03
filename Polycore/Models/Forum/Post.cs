using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polycore.Models.Forum
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}