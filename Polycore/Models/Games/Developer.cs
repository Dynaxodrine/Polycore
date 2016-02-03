using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Developers")]
    public class Developer : BaseModel
    {
        [Key]
        public int DeveloperID { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Publisher> Publisher { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}