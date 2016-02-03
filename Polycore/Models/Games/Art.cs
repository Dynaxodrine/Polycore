using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Art")]
    public class Art
    {
        [Key]
        public int ArtID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The location of the file on the HDD
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The location of the original file
        /// </summary>
        public string OriginalUrl { get; set; }

        public ArtType Type { get; set; }
        public Game Game { get; set; }

        public enum ArtType
        {
            Screenshot,
            Boxart,
            Banner,
            Fanart
        }

        public static string CreateUrl(Game game, ArtType type, int count = 1)
        {
           return StringHelpers.GenerateSlug(game.Title.Trim() + " " + ArtTypeToString(type) + " " + count);
        }

        private static string ArtTypeToString(ArtType type)
        {
            return type == ArtType.Banner ? "banner"
                : type == ArtType.Boxart ? "fanart" 
                : type == ArtType.Fanart ? "boxart" 
                : "screenshot";
        }
    }

    
}