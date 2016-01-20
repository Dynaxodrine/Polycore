using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("GameSubject")]
    public class GameSubjectModel
    {
        [Key]
        public int GameSubjectID { get; set; }
        public virtual GameModel Details { get; set; }

        public virtual ConsoleModel Console { get; set; }
        public virtual List<SubjectModel> Subjects { get; set; }
    }
}