using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Comments")]
    public class CommentModel
    {
        [Key]
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime? Commented { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual CommentModel CommentParent { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}