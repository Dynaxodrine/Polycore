using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polycore.Models
{
    [Table("Comments")]
    public class CommentModel
    {
        [Key]
        public int CommentID { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Comment is required.")]
        public string Content { get; set; }
        public DateTime? Commented { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual PostModel Post { get; set; }
        public virtual NewsArticleModel NewsArticle { get; set; }
        public virtual CommentModel CommentParent { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}