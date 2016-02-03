using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Polycore.Models.Forum;

namespace Polycore.Models.Games
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string YoutubeUrl { get; set; }
        public float Rating { get; set; }

        public virtual Esrb Esrb { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual Players Players { get; set; }
        public virtual CoOp CoOp { get; set; }
        public virtual Art Logo { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Platform> Platforms { get; set; }
        public virtual List<Game> SimilarGames { get; set; }
        public virtual List<GameSubject> Subjects { get; set; }

        public virtual List<Art> Fanart { get; set; }
        public virtual List<Art> Boxart { get; set; }
        public virtual List<Art> Screenshots { get; set; }
        public virtual List<Art> Banners { get; set; }
    }
}