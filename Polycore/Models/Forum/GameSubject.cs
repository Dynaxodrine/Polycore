using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Polycore.Models.Games;

namespace Polycore.Models.Forum
{
    [Table("GameSubject")]
    public class GameSubject
    {
        [Key]
        public int GameSubjectID { get; set; }
        public virtual Games.Game Details { get; set; }

        public virtual Platform Platform { get; set; }
        public virtual List<Subject> Subjects { get; set; }
    }
}