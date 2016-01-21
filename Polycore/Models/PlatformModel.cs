using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models
{
    [Table("Platforms")]
    public class PlatformModel
    {
        [Key]
        public int PlatformID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<GameModel> Games { get;  set; }
    }
}