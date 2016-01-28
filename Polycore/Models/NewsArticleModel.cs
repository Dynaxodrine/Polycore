﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polycore.Models
{
    [Table("NewsArticles")]
    public class NewsArticleModel
    {
        [Key]
        public int NewsArticleID { get; set; }
        [AllowHtml]
        [Required (ErrorMessage = "Title is required.")]        
        public string Title { get; set; }
        [AllowHtml]
        [Required (ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        [Required]
        public bool Hide { get; set; }
        public DateTime Published { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}