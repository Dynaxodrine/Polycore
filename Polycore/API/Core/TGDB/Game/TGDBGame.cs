using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.API.Core.TGDB.Game;

namespace Polycore.API.Core.TGDB
{
    public class TGDBGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string ESRB { get; set; }
        public List<string> Genres { get; set; }
        public string Players { get; set; }
        public string CoOp { get; set; }
        public string YoutubeUrl { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Rating { get; set; }
        public List<SimilarGame> SimilarGames { get; set; }
        public List<TGDBArt> Fanart { get; set; }
        public List<BoxArt> Boxart { get; set; }
        public List<TGDBArt> Screenshots { get; set; }
        public List<TGDBArt> Banner { get; set; }
        public TGDBArt Clearlogo { get; set; }

        public TGDBGame(int id, string title, int platformId, string platformName, string releaseDate, string overview, string esrb, List<string> genres, string players, string coOp, string youtubeUrl, string publisher, string developer, string rating, List<SimilarGame> similarGames, List<TGDBArt> fanart, List<BoxArt> boxart, List<TGDBArt> screenshots, List<TGDBArt> banner, TGDBArt clearlogo)
        {
            Id = id;
            Title = title;
            PlatformId = platformId;
            PlatformName = platformName;
            ReleaseDate = releaseDate;
            Overview = overview;
            ESRB = esrb;
            Genres = genres;
            Players = players;
            CoOp = coOp;
            YoutubeUrl = youtubeUrl;
            Publisher = publisher;
            Developer = developer;
            Rating = rating;
            SimilarGames = similarGames;
            Fanart = fanart;
            Boxart = boxart;
            Screenshots = screenshots;
            Banner = banner;
            Clearlogo = clearlogo;
        }

        public TGDBGame()
        {
            
        }
    }
}