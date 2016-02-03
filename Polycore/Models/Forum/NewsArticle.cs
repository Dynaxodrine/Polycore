using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Polycore.Models.Forum;

namespace Polycore.Models
{
    [Table("NewsArticles")]
    public class NewsArticle
    {
        [Key]
        public int NewsArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}