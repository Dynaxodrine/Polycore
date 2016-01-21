using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Games")]
    public class GameModel
    {
        [Key]
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual PlatformModel Platform { get; set; }
        public virtual List<SubjectModel> Subjects { get; set; }
    }
}