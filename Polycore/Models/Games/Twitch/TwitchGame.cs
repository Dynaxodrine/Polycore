using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games.Twitch
{
    [Table("TwitchGames")]
    public class TwitchGame
    {
        [Key]
        public int TwitchGameID { get; set; }
        public string Title { get; set; }
        public int TwitchId { get; set; }
        public int GiantBomb { get; set; }
        public virtual TwitchArt Boxart { get; set; }
        public virtual TwitchArt Logo { get; set; }
    }
}