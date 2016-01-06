using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Categories")]
    public class CategoryModels
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Console is required.")]
        public string Console { get; set; }
        [Required(ErrorMessage = "Game is required.")]
        public string Game { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public int SubjectId { get; set; }
    }
}