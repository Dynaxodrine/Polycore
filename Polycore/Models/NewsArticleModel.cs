using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("NewsArticles")]
    public class NewsArticleModel
    {
        [Key]
        public int NewsArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}