using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games.Twitch
{
    [Table("TwitchArt")]
    public class TwitchArt
    {
        [Key]
        public int TwitchArtID { get; set; }
        public virtual Art Large { get; set; }
        public virtual Art Medium { get; set; }
        public virtual Art Small { get; set; }
    }
}