using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("ForumPosts")]
    public class PostModels
    {
        [Key]
        public float MessageId { get; set; }
        public int ArticleId { get; set; }
        public string UserName { get; set; }       
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public DateTime Posted { get; set; }
    }
}