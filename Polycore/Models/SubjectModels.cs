using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Subjects")]
    public class SubjectModels
    {
        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}