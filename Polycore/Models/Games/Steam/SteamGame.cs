using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games.Steam
{
    [Table("SteamGames")]
    public class SteamGame
    {
        [Key]
        public int SteamGameID { get; set; }
        public string Title { get; set; }
        public int AppId { get; set; }
        public virtual Game Game { get; set; }
    }
}