using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Genre")]
    public class Genre : BaseModel
    {
        [Key]
        public int GenreID { get; set; }
        public List<Publisher> Publisher { get; set; }
        public List<Developer> Developers { get; set; }
    }
}