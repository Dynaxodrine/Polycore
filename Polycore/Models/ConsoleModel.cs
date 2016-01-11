using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Consoles")]
    public class ConsoleModel
    {
        [Key]
        public int ConsoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<GameModel> Games { get;  set; }
    }
}