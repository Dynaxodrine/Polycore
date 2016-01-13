using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Posts")]
    public class PostModel
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual CommentModel Comment { get; set; }
        public virtual SubjectModel Subject { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}