using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Polycore.Models.Games;

namespace Polycore.Models.Forum
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual Games.Game Game { get; set; }
        public virtual Subject SubjectParent { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}