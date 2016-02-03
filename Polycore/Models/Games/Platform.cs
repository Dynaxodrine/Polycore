using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Platforms")]
    public class Platform : BaseModel
    {
        [Key]
        public int PlatformId { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Publisher> Publisher { get; set; }
    }
}