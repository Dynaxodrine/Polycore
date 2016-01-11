using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Subjects")]
    public class SubjectModel
    {
        [Key]
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual GameModel Game { get; set; }
        public virtual SubjectModel SubjectParent { get; set; }
        public virtual List<SubjectModel> Subjects { get; set; }
        public virtual List<PostModel> Posts { get; set; }
    }
}