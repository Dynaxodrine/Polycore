using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}