using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Players")]
    public class Players : BaseModel
    {
        [Key]
        public int PlayersID { get; set; }
    }
}